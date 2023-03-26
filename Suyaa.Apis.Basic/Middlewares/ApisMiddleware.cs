using Egg;
using Egg.Lark;
using Egg.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Suyaa.Apis.Services.ApiManager;
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
        public ApisMiddleware(
            RequestDelegate next,
            IApiManager apiManager,
            ILogger logger,
            string path
            )
        {
            _next = next;
            _path = egg.IO.GetWorkPath(path);
            egg.IO.CreateFolder(_path);
            ((ApiManager)apiManager).SetPath(_path);
            logger.Debug($"ApisMiddleware '{path}' Loading ...", "Middlewares");
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
                string fullPath = egg.IO.CombinePath(_path, apiUrl + ".lark");
                if (!egg.IO.FileExists(fullPath)) throw new FriendlyException($"脚本文件'{apiUrl}'未找到");
                // 加载脚本
                string script = egg.IO.ReadUtf8FileContent(fullPath);
                using (var func = ScriptParser.Parse(script))
                using (var funcs = new Egg.Lark.ScriptFunctions())
                {
                    funcs.Reg<Suyaa.Apis.Plugs.Common.CommonFunction>();
                    using (Egg.Lark.ScriptEngine engine = new Egg.Lark.ScriptEngine(func, funcs))
                    {
                        //engine.SetMaxExecution(100000000);
                        try
                        {
                            // 执行脚本
                            var obj = engine.Execute();
                            ApiResult<object> result = new ApiResult<object>();
                            result.Data = obj;
                            // 输出结果
                            await result.ExecuteResultAsync(context);
                        }
                        catch (Exception ex)
                        {
                            ApiErrorResult result = new ApiErrorResult();
                            egg.Logger.Error($"【{apiUrl}】执行发生异常:" + ex.ToString(), "API");
                            result.Message = "执行发生异常：" + ex.Message;
                            // 输出结果
                            await result.ExecuteResultAsync(context);
                        }
                    }
                }
                return;
            }
            await _next(context);
        }
    }
}
