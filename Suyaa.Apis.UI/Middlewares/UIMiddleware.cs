﻿using Suyaa.Logs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Suyaa.Apis.UI.Extensions;
using Suyaa.Microservice.Exceptions;
using Suyaa.Microservice.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Suyaa.Helpers;
using Suyaa.Apis.UI.Middlewares.Dto;

namespace Suyaa.Apis.UI.Middlewares
{
    /// <summary>
    /// 默认页面中间件
    /// </summary>
    public class UIMiddleware
    {
        // 变量
        private RequestDelegate _next;
        private readonly UIMiddlewareDto _dto;

        /// <summary>
        /// 对象实例化
        /// </summary>
        /// <param name="next"></param>
        public UIMiddleware(RequestDelegate next, ILogger logger, UIMiddlewareDto dto)
        {
            _next = next;
            //Debug.WriteLine($"[UI] {_path}");
            logger.Debug($"UIMiddleware '{this.Path}' Loading ...", "Middlewares");
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
            // 404页面
            if (url == "/page/404")
            {
                string path = sy.IO.GetExecutionPath(this.Path + "/404.html");
                Debug.WriteLine($"[UI] Path: {path}");
                if (!sy.IO.FileExists(path))
                {
                    await context.Response.Render404Async();
                    return;
                }
                await context.Response.RenderFileAsync(path, "text/html");
                return;
            }
            // 静态直接输出
            if (url.StartsWith("/ui/"))
            {
                string file = url.Substring(4);
                // 兼容Vue
                if (file.IsNullOrWhiteSpace()) file = "index";
                string path = sy.IO.GetExecutionPath(this.Path + "/" + file);
                if (!sy.IO.FileExists(path))
                {
                    await context.Response.Render404Async();
                    return;
                }
                string ext = System.IO.Path.GetExtension(path).ToLower();
                string mime = string.Empty;
                switch (ext)
                {
                    case ".html": mime = "text/html"; break;
                    case ".css": mime = "text/css"; break;
                    case ".js": mime = "text/javascript"; break;
                    default: mime = "application/octet-stream"; break;
                }
                await context.Response.RenderFileAsync(path, mime);
                return;
            }
            // 页面路由
            if (url.StartsWith("/page/"))
            {
                string path = sy.IO.GetExecutionPath(this.Path + "/" + url.Substring(6) + ".html");
                if (!sy.IO.FileExists(path))
                {
                    context.Response.Redirect("/page/404");
                    return;
                }
                await context.Response.RenderFileAsync(path, "text/html");
                return;
            }
            // 脚本路由
            if (url.StartsWith("/js/"))
            {
                string path = sy.IO.GetExecutionPath(this.Path + "/" + url.Substring(4) + ".js");
                if (!sy.IO.FileExists(path))
                {
                    await context.Response.Render404Async();
                    return;
                }
                await context.Response.RenderFileAsync(path, "text/javascript");
                return;
            }
            // 脚本路由
            if (url.StartsWith("/css/"))
            {
                string path = sy.IO.GetExecutionPath(this.Path + "/" + url.Substring(5) + ".css");
                if (!sy.IO.FileExists(path))
                {
                    await context.Response.Render404Async();
                    return;
                }
                await context.Response.RenderFileAsync(path, "text/css");
                return;
            }
            await _next(context);
        }
    }
}
