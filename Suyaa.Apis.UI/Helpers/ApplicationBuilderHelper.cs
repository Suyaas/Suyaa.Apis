using Microsoft.AspNetCore.Builder;
using Suyaa.Apis.UI.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.UI.Helpers
{
    /// <summary>
    /// 应用程序构建帮助
    /// </summary>
    public static class ApplicationBuilderHelper
    {
        /// <summary>
        /// 使用默认页
        /// </summary>
        /// <param name="app"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseUI(this IApplicationBuilder app)
        {
            return app.UseMiddleware<UIMiddleware>();
        }
    }
}
