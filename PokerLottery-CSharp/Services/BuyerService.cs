using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokerLottery.EF.Domain;
using PokerLottery.EF;
using Microsoft.Extensions.Caching.Memory;
using PokerLottery.Configuration;

namespace PokerLottery.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly MysqlContext _mysqlContext;
        private readonly EfRepository<LotteryBuyer> _buyerRepository;
        private readonly IMemoryCache _memoryCache;

        public BuyerService(MysqlContext mysqlContext, IMemoryCache memoryCache)
        {
            this._mysqlContext = mysqlContext;
            _buyerRepository = new EfRepository<LotteryBuyer>(this._mysqlContext);
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
    }
}
