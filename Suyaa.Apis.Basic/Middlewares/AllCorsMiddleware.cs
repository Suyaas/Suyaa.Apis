using Suyaa.Logs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Suyaa.Hosting;
using Suyaa.Hosting.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Suyaa.Apis.Basic.Middlewares
{
    /// <summary>
    /// 令牌中间件
    /// </summary>
    public class AllCorsMiddleware
    {
        // 变量
        private RequestDelegate _next;

        private const string Cors_Header_Key = "Access-Control-Allow-Origin";

        /// <summary>
        /// 对象实例化
        /// </summary>
        /// <param name="next"></param>
        public AllCorsMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            logger.Debug($"AllCorsMiddleware Loading ...", "Middlewares");
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            if (!context.Response.Headers.ContainsKey(Cors_Header_Key))
                context.Response.Headers.Add(Cors_Header_Key, "*");
            await _next(context);
        }
    }
}
