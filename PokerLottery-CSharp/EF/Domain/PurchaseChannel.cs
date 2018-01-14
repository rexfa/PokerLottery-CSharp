using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokerLottery.EF;

namespace PokerLottery.EF.Domain
{
    public class PurchaseChannel:BaseEntity
    {
        public string ChannelName { get; set; }
        public string ChannelKey { get; set; }
        public string PushURL { get; set; }
    }
}
