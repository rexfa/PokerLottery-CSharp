using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerLottery.Models
{
    public class LotteryTicketModel
    {
        public int Id { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public DateTime OrderOn { get; set; }
        public int PoolCmd { get; set; }
        public int BuyerId { get; set; }
        public int IssueId { get; set; }
        public int Stat { get; set; }
        /// <summary>
        /// 获得类型
        /// </summary>
        public int Type { get; set; }
    }
}
