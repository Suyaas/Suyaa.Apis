using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Suyaa.Apis.Linux
{
    internal class Program
    {
        static void Main(string[] args)
        {
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