using Microsoft.AspNetCore.Builder;
using Suyaa.Apis.Basic.Middlewares;
using Suyaa.Apis.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Basic.Extensions
{
    /// <summary>
    /// 应用程序构建帮助
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// 使用默认页
        /// </summary>
        /// <param name="app"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseDefaultPage(this IApplicationBuilder app, string url) => app.UseMiddleware<DefaultPageMiddleware>(new object[] { url });

        /// <summary>
        /// 使用令牌交互
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseToken(this IApplicationBuilder app) => app.UseMiddleware<TokenMiddleware>();
    }
}
