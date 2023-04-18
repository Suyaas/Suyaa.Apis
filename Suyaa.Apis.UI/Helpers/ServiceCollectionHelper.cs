using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.FileIO;
using Suyaa.Apis.UI.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.UI.Helpers
{
    /// <summary>
    /// 容器助手
    /// </summary>
    public static class ServiceCollectionHelper
    {
        /// <summary>
        /// 添加UI界面配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IServiceCollection AddUI(this IServiceCollection services, Action<UIOptions> action)
        {
            var options = new UIOptions();
            action(options);
            services.AddSingleton(options);
            return services;
        }
    }
}
