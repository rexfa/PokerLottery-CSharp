using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokerLottery.EF.Domain;
using PokerLottery.Models;

namespace PokerLottery.Services
{
    public interface IBuyerService
    {
        LotteryBuyer AddBuyer(string BuyerChId,string BuyerChName,string Weixin,int ChannelId);
        IList<LotteryTicketModel> GetCurrentLotteysByBuyer(LotteryBuyer lotteryBuyer);
        IList<LotteryTicketModel> GetLotteysByBuyer(LotteryBuyer lotteryBuyer, int Backtrack = 0);

    }
}
