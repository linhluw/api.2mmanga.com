using Microsoft.Extensions.DependencyInjection;
using MyWeb.DAL.Interface;

namespace MyWeb.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan
            .FromAssemblyOf<ICategoryRepository>()
                 .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            return services;
        }
    }
}
