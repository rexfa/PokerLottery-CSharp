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
        /// <summary>
        /// 数据推送url
        /// </summary>
        public string PushURL { get; set; }
        /// <summary>
        /// 本平台数据获取url
        /// </summary>
        public string PullURL { get; set; }
    }
}
