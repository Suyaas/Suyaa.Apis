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

namespace Suyaa.Apis.Middlewares
{
    /// <summary>
    /// 默认页面中间件
    /// </summary>
    public class DefaultPageMiddleware
    {
        // 变量
        private RequestDelegate _next;
        private readonly string _url;

        /// <summary>
        /// 对象实例化
        /// </summary>
        /// <param name="next"></param>
        public DefaultPageMiddleware(RequestDelegate next, string url)
        {
            _next = next;
            _url = url;
            Debug.WriteLine($"[DefaultPage] {_url}");
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            string url = context.Request.Path.Value ?? "/";
            Debug.WriteLine($"[DefaultPage] Url: {url}");
            if (url == "/")
            {
                context.Response.Redirect(_url);
                return;
            }
            await _next(context);
        }
    }
}
