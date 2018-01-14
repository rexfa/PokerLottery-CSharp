using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokerLottery.EF;
namespace PokerLottery.EF.Domain
{
    public class BuyerIssue:BaseEntity
    {
        public int BuyerId { get; set; }
        public int IssueId { get; set; }
        /// <summary>
        /// 已购买数量
        /// </summary>
        public int PurchaseQuantity { get; set; }
 
    }
}
