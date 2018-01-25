using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokerLottery.EF.Domain;
using PokerLottery.EF;
using Microsoft.Extensions.Caching.Memory;
using PokerLottery.Configuration;
using PokerLottery.Models;

namespace PokerLottery.Services
{
    public class LotteryService : ILotteryService
    {
        private readonly MysqlContext _mysqlContext;
        private readonly EfRepository<BuyerIssue> _buyerIssueRepository;
        private readonly EfRepository<LotteryIssue> _issueRepository;
        private readonly EfRepository<LotteryPool0> _pool0Repository;
        private readonly EfRepository<LotteryPool1> _pool1Repository;
        private readonly IMemoryCache _memoryCache;
        public LotteryService(MysqlContext mysqlContext ,IMemoryCache memoryCache)
        {
            this._mysqlContext = mysqlContext;
            _buyerIssueRepository = new EfRepository<BuyerIssue>(this._mysqlContext);
            _issueRepository = new EfRepository<LotteryIssue>(this._mysqlContext);
            _pool0Repository = new EfRepository<LotteryPool0>(this._mysqlContext);
            _pool1Repository = new EfRepository<LotteryPool1>(this._mysqlContext);
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// 创建新一期彩票，要求上一期必须完成
        /// </summary>
        /// <param name="issueName"></param>
        /// <param name="beginTime"></param>
        /// <param name="stopTime"></param>
        /// <returns></returns>
        public bool ConstructNewIssue(string issueName, DateTime beginTime, DateTime stopTime)
        {
            int poolCmd = 0;
            var lastIssue =  _issueRepository.Table.OrderBy(i => i.CreatedOn).LastOrDefault();
            if (lastIssue != null)
            {
                if(lastIssue.PoolCmd == 0)
                    poolCmd = 1;
                if (lastIssue.Stat != (int)IssueStat.Accomplish)
                    throw new Exception("上一期没有完成，不能创建新一期。");
            }
            DateTime now = DateTime.Now;
            var newIssue = new LotteryIssue()
            {
                IssueName = issueName,
                BeginOn =  beginTime,
                StopOn = stopTime,
                OrderQuantity =0,
                Result = "",
                CreatedOn = now,
                PoolCmd = poolCmd,
                Stat = (int)IssueStat.Establish                
            };
            _issueRepository.Insert(newIssue);
            ConstructPool(poolCmd);
            return true;
        }
        public BuyerIssue SellLottery(LotteryBuyer lotteryBuyer, LotteryType lotteryType)
        {
            var issue = GetlatestIssue();
            if (issue == null)
                throw new Exception("没有找到本期数据。");
            if (issue.Stat != (int)IssueStat.Establish)
                throw new Exception("本期已经结束。");
            var buyerIssue = _buyerIssueRepository.Table.Where(bi => bi.BuyerId == lotteryBuyer.Id&&bi.IssueId==issue.Id).FirstOrDefault();
            if (buyerIssue == null)
            {
                buyerIssue = new BuyerIssue()
                {
                    BuyerId = lotteryBuyer.Id,
                    IssueId = issue.Id,
                    PurchaseQuantity = 0
                };
                _buyerIssueRepository.Insert(buyerIssue);
            }
            buyerIssue.PurchaseQuantity = buyerIssue.PurchaseQuantity + 1;

        }
        public LotteryIssue GetlatestIssue()
        {
            var issue = _issueRepository.Table.OrderByDescending(i => i.CreatedOn).FirstOrDefault();
            return issue;
        }

        public void LotteryDraws(LotteryIssue lotteryIssue, string LotteryParameters)
        {
            throw new NotImplementedException();
        }

        public void PreLotteryDraws(LotteryIssue lotteryIssue, string LotteryParameters)
        {
            throw new NotImplementedException();
        }

        #region Private
        /// <summary>
        /// 创建两个彩票池
        /// </summary>
        /// <param name="cmd"></param>
        private void ConstructPool(int cmd)
        {
            if (cmd == 0)
            {
                if (_pool0Repository.Table.Count() == 52 * 52 * 52 * 52)
                {
                    List<LotteryPool0> lp0s = new List<LotteryPool0>();
                    for (int i = 0; i < 52; i++)
                    {
                        for (int j = 0; j < 52; j++)
                        {
                            for (int k = 0; k < 52; k++)
                            {
                                for (int l = 0; l < 52; l++)
                                {
                                    var lp0 = new LotteryPool0()
                                    {
                                        A = i,
                                        B = j,
                                        C = k,
                                        D = l,
                                        Stat = (int)LotteryStat.Selling,
                                        Type = (int)LotteryType.NotProcessed,
                                        BuyerId = 0
                                    };
                                    lp0s.Add(lp0);
                                }
                            }
                        }
                    }
                    //_pool0Repository.Table.
                    _pool0Repository.InsertList(lp0s);
                }
                else
                {
                    //批量更新
                    var all0 = _pool0Repository.CurrentDbSet.ToList();
                    foreach (var p0 in all0)
                    {
                        p0.BuyerId = 0;
                        p0.Stat = 0;
                        p0.Type = 0;
                    }
                    _mysqlContext.SaveChanges();
                }
            }
            else if (cmd == 1)
            {
                if (_pool0Repository.Table.Count() == 52 * 52 * 52 * 52)
                {
                    List<LotteryPool1> lp1s = new List<LotteryPool1>();
                    for (int i = 0; i < 52; i++)
                    {
                        for (int j = 0; j < 52; j++)
                        {
                            for (int k = 0; k < 52; k++)
                            {
                                for (int l = 0; l < 52; l++)
                                {
                                    var lp1 = new LotteryPool1()
                                    {
                                        A = i,
                                        B = j,
                                        C = k,
                                        D = l,
                                        Stat = (int)LotteryStat.Selling,
                                        Type = (int)LotteryType.NotProcessed,
                                        BuyerId = 0
                                    };
                                    lp1s.Add(lp1);
                                }
                            }
                        }
                    }
                    //_pool1Repository.Table.
                    _pool1Repository.InsertList(lp1s);
                }
                else
                {
                    //批量更新
                    var all1 = _pool1Repository.CurrentDbSet.ToList();
                    foreach (var p1 in all1)
                    {
                        p1.BuyerId = 0;
                        p1.Stat = 0;
                        p1.Type = 0;
                    }
                    _mysqlContext.SaveChanges();
                }
            }
        }

        private LotteryTicketModel SendLotteryTicket(BuyerIssue buyerIssue, LotteryIssue lotteryIssue)
        {
            Random rd0 = new Random();
            int a0 = rd0.Next(100) % 52;
            int b0 = rd0.Next(100) % 52;
            int c0 = rd0.Next(100) % 52;
            int d0 = rd0.Next(100) % 52;

        }
        #region Pool0
        private LotteryPool0 GetTicketInLotteryPool0(int a ,int b, int c ,int d,int buyerId,int sellType)
        {
            var p0 = _pool0Repository.Table.Where(p => p.A == a && p.B == b && p.C == c && p.D == d).First();
            if (p0.Stat == (int)LotteryStat.Selling)
            {
                p0.Stat = (int)LotteryStat.Sold;
                p0.Type = sellType;
                p0.OrderTime = DateTime.Now;
                p0.BuyerId = buyerId;
                _mysqlContext.SaveChanges();
                return p0;
            }
            else
            {
                return GetSellingTicket0(p0, 1);
            }
        }
        private LotteryPool0 GetSellingTicket0(LotteryPool0 lotteryPool0, int direction)
        {
            var lp0 = _pool0Repository.GetById(lotteryPool0.Id + direction);
            if (lp0 != null)
            {
                direction = 0 - direction;
                lp0 = GetSellingTicket0(lotteryPool0, direction);
                return lp0;
            }
            else
            {
                if (lp0.Stat == (int)LotteryStat.Selling)
                {
                    return lp0;
                }
                else
                {
                    int abs = Math.Abs(direction);
                    int i = direction / abs;
                    abs++;
                    direction = i * abs;
                    lp0 = GetSellingTicket0(lotteryPool0, direction);
                    return lp0;
                }
            }            
        }
        #endregion
        #region Pool1
        private LotteryPool1 GetTicketInLotteryPool1(int a, int b, int c, int d, int buyerId, int sellType)
        {
            var p1 = _pool1Repository.Table.Where(p => p.A == a && p.B == b && p.C == c && p.D == d).First();
            if (p1.Stat == (int)LotteryStat.Selling)
            {
                p1.Stat = (int)LotteryStat.Sold;
                p1.Type = sellType;
                p1.OrderTime = DateTime.Now;
                p1.BuyerId = buyerId;
                _mysqlContext.SaveChanges();
                return p1;
            }
            else
            {
                return GetSellingTicket1(p1, 1);
            }
        }
        private LotteryPool1 GetSellingTicket1(LotteryPool1 lotteryPool1, int direction)
        {
            var lp1 = _pool1Repository.GetById(lotteryPool1.Id + direction);
            if (lp1 != null)
            {
                direction = 0 - direction;
                lp1 = GetSellingTicket1(lotteryPool1, direction);
                return lp1;
            }
            else
            {
                if (lp1.Stat == (int)LotteryStat.Selling)
                {
                    return lp1;
                }
                else
                {
                    int abs = Math.Abs(direction);
                    int i = direction / abs;
                    abs++;
                    direction = i * abs;
                    lp1 = GetSellingTicket1(lotteryPool1, direction);
                    return lp1;
                }
            }
        }
        #endregion
        #endregion
    }
}
