﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokerLottery.EF;
namespace PokerLottery.EF.Domain
{
    public class LotteryBuyer:BaseEntity
    {
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
    }
}