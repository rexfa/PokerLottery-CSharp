using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerLottery.Services
{
    public interface IBuyerService
    {
        void AddBuyer(string BuyerChId,int ChannelId);
    }
}
