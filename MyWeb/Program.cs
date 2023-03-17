using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyWeb.Data;
using System;
using System.Threading.Tasks;

namespace MyWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            Task.Factory.StartNew(async () =>
            {
                using (var scope = host.Services.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;

                    try
                    {
                        var dbInitializer = serviceProvider.GetService<IDbInitializer>();
                        await dbInitializer.SeedFromServiceCacheToInstanceCache();
                    }
                    catch (Exception ex)
                    {
                        var _logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                        _logger.LogError(ex, "Có lỗi khi seeding data.");
                    }
                }
            });
            host.Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
}
