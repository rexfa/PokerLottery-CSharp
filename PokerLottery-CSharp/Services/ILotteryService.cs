using System;
using PokerLottery.EF.Domain;
using PokerLottery.Configuration;
namespace PokerLottery.Services
{
    public interface ILotteryService
    {
        bool ConstructNewIssue(string issueName,DateTime beginTime,DateTime stopTime);
        BuyerIssue SellLottery(LotteryBuyer lotteryBuyer, LotteryType lotteryType );
        void LotteryDraws(LotteryIssue lotteryIssue,string LotteryParameters);
        void PreLotteryDraws(LotteryIssue lotteryIssue, string LotteryParameters);
        LotteryIssue GetlatestIssue();
    }
}
