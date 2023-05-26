using Microsoft.Extensions.DependencyInjection;
using Suyaa.Hosting;
using Suyaa.Hosting.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Common.Apps
{
    /// <summary>
    /// 模块启动器
    /// </summary>
    public class ModuleStartup : IModuleStartup
    {
        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddModuler<Cores.ModuleStartup>();
        }
    }
}
