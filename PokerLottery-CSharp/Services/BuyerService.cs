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
    public class BuyerService : IBuyerService
    {
        private readonly MysqlContext _mysqlContext;
        private readonly EfRepository<LotteryBuyer> _buyerRepository;
        private readonly EfRepository<LotteryPool0> _pool0Repository;
        private readonly EfRepository<LotteryPool1> _pool1Repository;
        private readonly EfRepository<LotteryIssue> _issueRepository;
        private readonly IMemoryCache _memoryCache;

        public BuyerService(MysqlContext mysqlContext, IMemoryCache memoryCache)
        {
            this._mysqlContext = mysqlContext;
            _buyerRepository = new EfRepository<LotteryBuyer>(this._mysqlContext);
            _pool0Repository = new EfRepository<LotteryPool0>(this._mysqlContext);
            _pool1Repository = new EfRepository<LotteryPool1>(this._mysqlContext);
            _issueRepository = new EfRepository<LotteryIssue>(this._mysqlContext);
            _memoryCache = memoryCache;
        }
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="BuyerChId"></param>
        /// <param name="BuyerChName"></param>
        /// <param name="Weixin"></param>
        /// <param name="ChannelId"></param>
        /// <returns></returns>
        public LotteryBuyer AddBuyer(string BuyerChId, string BuyerChName, string Weixin, int ChannelId)
        {
            var now = DateTime.Now;
            var newBuyer = new LotteryBuyer()
            {
                ChannelId = ChannelId,
                BuyerChName = BuyerChName,
                Weixin = Weixin,
                ChannelSysId = BuyerChId,
                CreatedOn = now
            };
            _buyerRepository.Insert(newBuyer);
            return newBuyer;
        }
        /// <summary>
        /// 活的用户已经持有的当前期彩票
        /// </summary>
        /// <param name="lotteryBuyer"></param>
        /// <returns></returns>
        public IList<LotteryTicketModel> GetCurrentLotteysByBuyer(LotteryBuyer lotteryBuyer)
        {
            var issue = _issueRepository.Table.OrderByDescending(i => i.CreatedOn).FirstOrDefault();
            if (issue.Stat == (int)IssueStat.Accomplish)
                throw new Exception("当前期没有生成。");
            List<LotteryTicketModel> models = new List<LotteryTicketModel>();
            if (issue.PoolCmd==0)
            {
                var lp0s = _pool0Repository.Table.Where(pl0 => pl0.BuyerId == lotteryBuyer.Id).ToList();
                foreach (var lp0 in lp0s)
                {
                    LotteryTicketModel model = new LotteryTicketModel()
                    {
                        A = lp0.A,
                        B = lp0.B,
                        C = lp0.C,
                        D = lp0.D,
                        BuyerId = lp0.BuyerId,
                        Id = lp0.Id,
                        IssueId = issue.Id,
                        OrderOn = lp0.OrderTime,
                        PoolCmd = issue.PoolCmd,
                        Stat = lp0.Stat,
                        Type = lp0.Type
                    };
                    models.Add(model);
                }
            }
            else if(issue.PoolCmd==1)
            {
                var lp1s = _pool1Repository.Table.Where(pl1 => pl1.BuyerId == lotteryBuyer.Id).ToList();
                foreach (var lp1 in lp1s)
                {
                    LotteryTicketModel model = new LotteryTicketModel()
                    {
                        A = lp1.A,
                        B = lp1.B,
                        C = lp1.C,
                        D = lp1.D,
                        BuyerId = lp1.BuyerId,
                        Id = lp1.Id,
                        IssueId = issue.Id,
                        OrderOn = lp1.OrderTime,
                        PoolCmd = issue.PoolCmd,
                        Stat = lp1.Stat,
                        Type = lp1.Type
                    };
                    models.Add(model);
                }
            }
            else { throw new Exception("奖池命令错误！"); }
            return models;
        }
        /// <summary>
        /// 活的用户所有的彩票
        /// </summary>
        /// <param name="lotteryBuyer"></param>
        /// <param name="Backtrack"></param>
        /// <returns></returns>
        public IList<LotteryTicketModel> GetLotteysByBuyer(LotteryBuyer lotteryBuyer, int Backtrack = 0)
        {
            var issues = _issueRepository.Table.OrderByDescending(i => i.CreatedOn).Take(Backtrack + 1);
            LotteryIssue issue = null;
            if (issues.Count() == Backtrack + 1)
            {
                throw new Exception("索引已经越界");
            }
            else
            {
                issue = issues.Last();
            }
            if (issue.Stat == (int)IssueStat.Accomplish)
                throw new Exception("当前期没有生成。");
            List<LotteryTicketModel> models = new List<LotteryTicketModel>();
            if (issue.PoolCmd == 0)
            {
                var lp0s = _pool0Repository.Table.Where(pl0 => pl0.BuyerId == lotteryBuyer.Id).ToList();
                foreach (var lp0 in lp0s)
                {
                    LotteryTicketModel model = new LotteryTicketModel()
                    {
                        A = lp0.A,
                        B = lp0.B,
                        C = lp0.C,
                        D = lp0.D,
                        BuyerId = lp0.BuyerId,
                        Id = lp0.Id,
                        IssueId = issue.Id,
                        OrderOn = lp0.OrderTime,
                        PoolCmd = issue.PoolCmd,
                        Stat = lp0.Stat,
                        Type = lp0.Type
                    };
                    models.Add(model);
                }
            }
            else if (issue.PoolCmd == 1)
            {
                var lp1s = _pool1Repository.Table.Where(pl1 => pl1.BuyerId == lotteryBuyer.Id).ToList();
                foreach (var lp1 in lp1s)
                {
                    LotteryTicketModel model = new LotteryTicketModel()
                    {
                        A = lp1.A,
                        B = lp1.B,
                        C = lp1.C,
                        D = lp1.D,
                        BuyerId = lp1.BuyerId,
                        Id = lp1.Id,
                        IssueId = issue.Id,
                        OrderOn = lp1.OrderTime,
                        PoolCmd = issue.PoolCmd,
                        Stat = lp1.Stat,
                        Type = lp1.Type
                    };
                    models.Add(model);
                }
            }
            else { throw new Exception("奖池命令错误！"); }
            return models;
        }
    }
}
