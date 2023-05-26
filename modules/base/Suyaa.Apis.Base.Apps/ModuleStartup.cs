﻿using Microsoft.Extensions.DependencyInjection;
using Suyaa.Hosting;
using Suyaa.Hosting.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Apis.Base.Apps
{
    public class ModuleStartup : IModuleStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddModuler<Cores.ModuleStartup>();
        }
    }
}
