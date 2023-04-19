using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Security.AccessControl;
using Suyaa.Microservice.Extensions;
using Suyaa.Apis.Basic.ActionFilters;
using Suyaa.Apis.UI.Helpers;
using Suyaa.Apis.Basic.Helpers;

namespace Suyaa.Apis.Full
{
    /// <summary>
    /// 启动器
    /// </summary>
    public class Startup : Suyaa.Microservice.Startup
    {
        /// <summary>
        /// 启动器
        /// </summary>
        /// <param name="configuration">配置</param>
        public Startup(IConfiguration configuration) : base(configuration) { }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            this.Import<ModuleStartup>();
            this.Import<Common.Apps.ModuleStartup>();
            this.Import<Base.Apps.ModuleStartup>();
            this.Import<Lark.Apps.ModuleStartup>();
            this.Import<User.Apps.ModuleStartup>();
        }

        protected override void OnConfigureServices(IServiceCollection services)
        {
            base.OnConfigureServices(services);

            // 添加UI配置
            services.AddUI(opt =>
            {
                opt.AddPath("ui");
            });
        }

        protected override void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.OnConfigure(app, env);

            // 使用UI
            app.UseUI();
            // 使用默认页
            app.UseDefaultPage("/ui/index.html");
            // 使用令牌
            app.UseToken();
            // 使用API
            app.UseApis("lark");
        }
    }
}
