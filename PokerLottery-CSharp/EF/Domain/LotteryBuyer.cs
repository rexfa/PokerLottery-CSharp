using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokerLottery.EF;
namespace PokerLottery.EF.Domain
{
    public class LotteryBuyer:BaseEntity
    {
        public int ChannelId { get; set; }
        public string BuyerChName { get; set; }
        public string ChannelSysId { get; set; }
        public string Weixin { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<LotteryHistory> LotteryHistorys { get; set; }
    }
}
