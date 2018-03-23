using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokerLottery.Models;
using PokerLottery.Services;
namespace PokerLottery.Controllers
{
    [Produces("application/json")]
    [Route("api/LotteryAPI")]
    public class LotteryAPIController : Controller
    {
        private readonly ILotteryService _lotteryService;
        private readonly IBuyerService _buyerService;
        public LotteryAPIController(ILotteryService lotteryService, IBuyerService buyerService)
        {
            _lotteryService = lotteryService;
            _buyerService = buyerService;
        }
        public LotteryTicketModel BuyLottery(string userToken,string sellType)
        {

        }
        public IEnumerable<LotteryTicketModel> GetLottery(string userToken)
        { }
    }
}