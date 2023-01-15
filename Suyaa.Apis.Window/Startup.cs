using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Suyaa.Apis.Window
{
    internal class Startup : Suyaa.Microservice.Startup
    {
        /// <summary>
        /// 启动器
        /// </summary>
        /// <param name="configuration">配置</param>
        public Startup(IConfiguration configuration) : base(configuration) { }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            //this.Import<Test.ModuleStartup>();
        }

        protected override void OnConfigureServices(IServiceCollection services)
        {
            base.OnConfigureServices(services);
        }

        protected override void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.OnConfigure(app, env);

            // 使用静态文件
            app.UseStaticFiles();
        }
    }
}
