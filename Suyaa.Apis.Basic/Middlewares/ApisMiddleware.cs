using Suyaa;
using Suyaa.Script;
using Suyaa.Logs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Suyaa.Apis.Services.ApiManager;
using Suyaa.Apis.Services.LarkScriptFunctions;
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
    /// 默认页面中间件
    /// </summary>
    public class ApisMiddleware
    {
        // 变量
        private RequestDelegate _next;
        private readonly IServiceProvider _provider;
        private readonly string _path;

        /// <summary>
        /// 对象实例化
        /// </summary>
        /// <param name="next"></param>
        public ApisMiddleware(
            RequestDelegate next,
            IApiManager apiManager,
            ILogger logger,
            IServiceProvider provider,
            string path
            )
        {
            _next = next;
            _provider = provider;
            _path = sy.IO.GetWorkPath(path);
            sy.IO.CreateFolder(_path);
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
                string fullPath = sy.IO.CombinePath(_path, apiUrl + ".lark");
                if (!sy.IO.FileExists(fullPath)) throw new HostFriendlyException($"脚本文件'{apiUrl}'未找到");
                // 加载脚本
                string script = sy.IO.ReadUtf8FileContent(fullPath);
                var larkEngineCore = _provider.GetRequiredService<ILarkEngineCore>();
                using (var sf = ScriptParser.Parse(script))
                using (Suyaa.Script.ScriptEngine engine = new Suyaa.Script.ScriptEngine(sf, larkEngineCore.ScriptFunctions))
                {
                    //engine.SetMaxExecution(100000000);
                    engine.Put<IServiceProvider>(_provider);
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
                        sy.Logger.Error($"【{apiUrl}】执行发生异常:" + ex.ToString(), "API");
                        result.Message = "执行发生异常：" + ex.Message;
                        // 输出结果
                        await result.ExecuteResultAsync(context);
                    }
                }
                return;
            }
            await _next(context);
        }
    }
}
