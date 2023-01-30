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

namespace Suyaa.Apis.UI.Middlewares
{
    /// <summary>
    /// 默认页面中间件
    /// </summary>
    public class UIMiddleware
    {
        // 变量
        private RequestDelegate _next;
        private readonly string _path;

        /// <summary>
        /// 对象实例化
        /// </summary>
        /// <param name="next"></param>
        public UIMiddleware(RequestDelegate next, string path)
        {
            _next = next;
            _path = path;
            Debug.WriteLine($"[UI] {_path}");
        }

        // 呈现文档
        private async Task Render(HttpResponse response, string path, string contentType)
        {
            response.StatusCode = 200;
            response.ContentType = contentType;
            byte[] buffer = new byte[1024];
            using (var f = egg.IO.OpenFile(path))
            {
                response.ContentLength = f.Length;
                int len = 0;
                do
                {
                    len = f.Read(buffer, 0, buffer.Length);
                    if (len > 0) await response.Body.WriteAsync(buffer, 0, len);
                } while (len > 0);
            }
            await response.Body.FlushAsync();
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
                string path = egg.IO.GetExecutionPath(_path + "/404.html");
                Debug.WriteLine($"[UI] Path: {path}");
                if (!egg.IO.CheckFileExists(path))
                {
                    context.Response.Clear();
                    context.Response.StatusCode = 404;
                    context.Response.ContentType = "text/plain";
                    await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Not found 404."));
                    return;
                }
                await Render(context.Response, path, "text/html");
            }
            // 页面路由
            if (url.StartsWith("/page/"))
            {
                string path = egg.IO.GetExecutionPath(_path + "/" + url.Substring(6) + ".html");
                if (!egg.IO.CheckFileExists(path))
                {
                    context.Response.Redirect("/page/404");
                    return;
                }
                await Render(context.Response, path, "text/html");
            }
            // 脚本路由
            if (url.StartsWith("/ui/"))
            {
                string path = egg.IO.GetExecutionPath(_path + "/" + url.Substring(4));
                if (!egg.IO.CheckFileExists(path))
                {
                    context.Response.Clear();
                    context.Response.StatusCode = 404;
                    context.Response.ContentType = "text/plain";
                    await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Not found 404."));
                    return;
                }
                string ext = System.IO.Path.GetExtension(path).ToLower();
                switch (ext)
                {
                    case ".js":
                        await Render(context.Response, path, "text/javascript");
                        break;
                    case ".css":
                        await Render(context.Response, path, "text/css");
                        break;
                    default:
                        context.Response.Clear();
                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "text/plain";
                        await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes($"File '{ext}' not support."));
                        break;
                }
            }
            // 脚本路由
            if (url.StartsWith("/js/"))
            {
                string path = egg.IO.GetExecutionPath(_path + "/" + url.Substring(4) + ".js");
                if (!egg.IO.CheckFileExists(path))
                {
                    context.Response.Clear();
                    context.Response.StatusCode = 404;
                    context.Response.ContentType = "text/plain";
                    await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Not found 404."));
                    return;
                }
                await Render(context.Response, path, "text/javascript");
            }
            // 脚本路由
            if (url.StartsWith("/css/"))
            {
                string path = egg.IO.GetExecutionPath(_path + "/" + url.Substring(5) + ".css");
                if (!egg.IO.CheckFileExists(path))
                {
                    context.Response.Clear();
                    context.Response.StatusCode = 404;
                    context.Response.ContentType = "text/plain";
                    await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Not found 404."));
                    return;
                }
                await Render(context.Response, path, "text/css");
            }
            await _next(context);
        }
    }
}
