using Suyaa.Logs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Suyaa.Microservice.Exceptions;
using Suyaa.Microservice.Results;
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
    public class TokenMiddleware
    {
        // 变量
        private RequestDelegate _next;

        /// <summary>
        /// 对象实例化
        /// </summary>
        /// <param name="next"></param>
        public TokenMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            logger.Debug($"TokenMiddleware Loading ...", "Middlewares");
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}
