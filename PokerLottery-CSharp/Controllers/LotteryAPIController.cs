using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokerLottery.Models;
namespace PokerLottery.Controllers
{
    [Produces("application/json")]
    [Route("api/LotteryAPI")]
    public class LotteryAPIController : Controller
    {
        public LotteryTicketModel BuyLottery(string userToken,string sellType)
        { }
        public IEnumerable<LotteryTicketModel> GetLottery(string userToken)
        { }
    }
}