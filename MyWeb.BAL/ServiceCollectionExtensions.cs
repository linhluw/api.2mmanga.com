using Microsoft.Extensions.DependencyInjection;
using MyWeb.BAL.Cache;
using MyWeb.BAL.Service;

namespace MyWeb.BAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICacheData, CacheData>();

            services.Scan(scan => scan
           .FromAssemblyOf<ISanPhamService>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                   .AsImplementedInterfaces()
                   .WithScopedLifetime());
            return services;
        }
    }
}
