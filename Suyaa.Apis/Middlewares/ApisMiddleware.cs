using Egg;
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
    public class ApisMiddleware
    {
        // 变量
        private RequestDelegate _next;
        private readonly string _path;

        /// <summary>
        /// 对象实例化
        /// </summary>
        /// <param name="next"></param>
        public ApisMiddleware(RequestDelegate next, string path)
        {
            _next = next;
            _path = path;
            Debug.WriteLine($"[Apis] Path: {_path}");
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
            if (url.StartsWith("/api/"))
            {
                string apiUrl = url.Substring(5);
                int apiSceneIndex = apiUrl.IndexOf('/');
                //context.Response.StatusCode = 200;
                //context.Response.ContentType = "text/plain";
                ApiResult<string> result = new ApiResult<string>();
                result.Data = apiUrl;
                //await context.Response.Body.WriteAsync(JsonSerializer.Serialize(result).ToUtf8Bytes());
                await result.ExecuteResultAsync(context);
                return;
            }
            await _next(context);
        }
    }
}
