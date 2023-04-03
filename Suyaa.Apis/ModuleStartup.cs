using Suyaa.Logs;
using Suyaa.Logs.Loggers;
using Microsoft.Extensions.DependencyInjection;
using Suyaa.Apis.Services.ApiManager;
using Suyaa.Microservice;
using Suyaa.Microservice.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis
{
    public class ModuleStartup : IModuleStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // 注册Api管理器
            var apiManager = new ApiManager();
            services.AddSingleton<IApiManager>(apiManager);
        }
    }
}
