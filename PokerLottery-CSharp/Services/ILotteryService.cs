using System;
using PokerLottery.EF.Domain;
namespace PokerLottery.Services
{
    public interface ILotteryService
    {
        bool ConstructNewIssue(string issueName,DateTime beginTime,DateTime stopTime);
        void LotteryDraws(LotteryIssue lotteryIssue,string LotteryParameters);
        void PreLotteryDraws(LotteryIssue lotteryIssue, string LotteryParameters);
    }
}
