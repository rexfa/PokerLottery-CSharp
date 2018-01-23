using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokerLottery.EF.Domain;

namespace PokerLottery.Services
{
    public interface IBuyerService
    {
        LotteryBuyer AddBuyer(string BuyerChId,string BuyerChName,string Weixin,int ChannelId);
    }
}
