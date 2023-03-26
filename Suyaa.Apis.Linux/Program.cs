using Egg;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Suyaa.Apis.Basic;

namespace Suyaa.Apis.Linux
{
    internal class Program
    {
        // 环境变量关键字
        private const string KEY_ASPNETCORE_ENVIRONMENT = "ASPNETCORE_ENVIRONMENT";

        static void Main(string[] args)
        {
            if (Environment.GetEnvironmentVariable(KEY_ASPNETCORE_ENVIRONMENT).IsNullOrWhiteSpace()) Environment.SetEnvironmentVariable(KEY_ASPNETCORE_ENVIRONMENT, "Production");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .AddCommandLine(args);
            var config = builder.Build();
            Suyaa.Microservice.WebHost.CreateHostBuilder<Startup>(webBuilder => webBuilder.UseConfiguration(config), args).Build().Run();
        }
    }
}