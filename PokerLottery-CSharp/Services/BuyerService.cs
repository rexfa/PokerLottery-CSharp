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

        public IList<LotteryTicketModel> GetCurrentLotteysByBuyer(LotteryBuyer lotteryBuyer)
        {
            var issue = _issueRepository.Table.OrderByDescending(i => i.CreatedOn).FirstOrDefault();
            if (issue.Stat == (int)IssueStat.Accomplish)
                throw new Exception("当前期没有生成。");
            if(issue.PoolCmd==0)
            { }
            else if(issue.PoolCmd==1)
            { }
            else { throw new Exception("奖池命令错误！"); }
        }
    }
}
