using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokerLottery.EF;
namespace PokerLottery.EF.Domain
{
    public class LotteryIssue:BaseEntity
    {
        public string IssueName { get; set; }
        /// <summary>
        /// 本期彩票设定
        /// </summary>
        public string IssueSetting { get; set; }
        public string LotteryParameters { get; set; }
        /// <summary>
        /// 结果集，储存序列化对象
        /// </summary>
        public string Result { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime BeginOn { get; set; }
        public DateTime StopOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
