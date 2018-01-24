using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using PokerLottery.EF;
using PokerLottery.EF.Domain;

namespace PokerLottery.Middlewares
{
    public class InstallDatabaseMiddleware
    {
        /// <summary>
        /// 中间件管道代理对象
        /// </summary>
        private readonly RequestDelegate _next;
        private readonly MysqlContext _mysqlContext;
        public InstallDatabaseMiddleware(RequestDelegate next, MysqlContext mysqlContext)
        {
            _next = next;
            _mysqlContext = mysqlContext;
        }
        /// <summary>
        /// 调用管道
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext context)
        {
            return this._next(context);
        }
    }
}
