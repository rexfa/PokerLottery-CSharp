using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokerLottery.EF;

namespace PokerLottery.EF.Domain
{
    public class LotteryPool0:BaseEntity
    {
        public int BuyerId { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        /// <summary>
        /// 状态，是否卖出或锁定等
        /// </summary>
        public int Stat { get; set; }
        /// <summary>
        /// 获得类型
        /// </summary>
        public int Type { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
