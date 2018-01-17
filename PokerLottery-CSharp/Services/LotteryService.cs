using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokerLottery.EF.Domain;
using PokerLottery.EF;
using Microsoft.Extensions.Caching.Memory;

namespace PokerLottery.Services
{
    public class LotteryService : ILotteryService
    {
        private readonly MysqlContext _mysqlContext;
        private readonly EfRepository<LotteryIssue> _issueRepository;
        private readonly IMemoryCache _memoryCache;
        public LotteryService(MysqlContext mysqlContext ,IMemoryCache memoryCache)
        {
            this._mysqlContext = mysqlContext;
            _issueRepository = new EfRepository<LotteryIssue>(this._mysqlContext);
            _memoryCache = memoryCache;
        }
        public bool ConstructNewIssue(string issueName, DateTime beginTime, DateTime stopTime)
        {
            throw new NotImplementedException();
        }

        public void LotteryDraws(LotteryIssue lotteryIssue, string LotteryParameters)
        {
            throw new NotImplementedException();
        }

        public void PreLotteryDraws(LotteryIssue lotteryIssue, string LotteryParameters)
        {
            throw new NotImplementedException();
        }
    }
}
