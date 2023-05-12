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
using Suyaa.Apis.UI.Helpers;
using Suyaa.Apis.UI.Options;

namespace Suyaa.Apis.UI.Middlewares
{
    /// <summary>
    /// 默认页面中间件
    /// </summary>
    public class UIMiddleware
    {
        // 变量
        private RequestDelegate _next;
        private readonly UIOptions _options;

        /// <summary>
        /// 对象实例化
        /// </summary>
        /// <param name="next"></param>
        public UIMiddleware(RequestDelegate next, ILogger logger, UIOptions options)
        {
            _next = next;
            _options = options;
            //Debug.WriteLine($"[UI] {_path}");
            if (options is null) throw new FriendlyException($"缺少UI路径配置");
            if (options.Paths.Count <= 0) throw new FriendlyException($"缺少UI路径配置");
            logger.Debug($"UIMiddleware '{options.Paths.Count}' Loading ...", "Middlewares");
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            string url = context.Request.Path.Value ?? "/";
            Debug.WriteLine($"[UI] Url: {url}");
            // 循环输出结果
            foreach (var path in _options.Paths)
            {
                if (!url.StartsWith(path.UrlPath)) continue;
                string file = url.Substring(path.UrlPath.Length);
                // 兼容Vue
                if (file.IsNullOrWhiteSpace()) file = "index.html";
                string filePath = sy.IO.GetExecutionPath(path.Path + "/" + file);
                // 处理
                if (!sy.IO.FileExists(filePath))
                {
                    if (!_options.Page404.IsNullOrWhiteSpace() && url != _options.Page404)
                    {
                        context.Response.Redirect(_options.Page404);
                    }
                    else
                    {
                        await context.Response.Render404Async();
                    }
                    return;
                }
                string ext = System.IO.Path.GetExtension(filePath).ToLower();
                string mime = string.Empty;
                switch (ext)
                {
                    case ".html": mime = "text/html"; break;
                    case ".css": mime = "text/css"; break;
                    case ".js": mime = "text/javascript"; break;
                    default: mime = "application/octet-stream"; break;
                }
                await context.Response.RenderFileAsync(filePath, mime);
                return;
            }
            await _next(context);
        }
    }
}
