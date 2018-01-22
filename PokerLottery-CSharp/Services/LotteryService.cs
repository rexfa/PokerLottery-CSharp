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
        private readonly EfRepository<LotteryPool0> _pool0Repository;
        private readonly EfRepository<LotteryPool1> _pool1Repository;
        private readonly IMemoryCache _memoryCache;
        public LotteryService(MysqlContext mysqlContext ,IMemoryCache memoryCache)
        {
            this._mysqlContext = mysqlContext;
            _issueRepository = new EfRepository<LotteryIssue>(this._mysqlContext);
            _pool0Repository = new EfRepository<LotteryPool0>(this._mysqlContext);
            _pool1Repository = new EfRepository<LotteryPool1>(this._mysqlContext);
            _memoryCache = memoryCache;
        }
        public bool ConstructNewIssue(string issueName, DateTime beginTime, DateTime stopTime)
        {
            DateTime now = DateTime.Now;
            var newIssue = new LotteryIssue()
            {
                IssueName = issueName,
                BeginOn =  beginTime,
                StopOn = stopTime,
                OrderQuantity =0,
                Result = "",
                CreatedOn = now
            };
            _issueRepository.Insert(newIssue);
            
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
        private void ConstructPool(int cmd)
        {
            if (cmd == 0)
            {
                if (_pool0Repository.Table.Count() != 52 * 52 * 52 * 52)
                {
                }
                
            }
        }
        #endregion
    }
}
