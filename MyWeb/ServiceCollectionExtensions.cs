using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWeb.Quartz;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;

namespace MyWeb
{
    public static class ServiceCollectionExtensions
    {
        private const string QuartzSectionName = "Quartz";

        public static IServiceCollection AddQuartz(this IServiceCollection services)
        {
            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();

            var quartzOptions = new QuartzOptions();
            config.Bind(QuartzSectionName, quartzOptions);
            services.AddSingleton(quartzOptions);
            services.Configure<QuartzOptions>(config.GetSection(QuartzSectionName));
            // Add Quartz services
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            if (quartzOptions != null && quartzOptions.Enabled)
            {
                foreach (var item in quartzOptions.JobOption)
                {
                    if (item.Enabled)
                    {
                        var type = Type.GetType($"{item.JobType}");

                        services.AddSingleton(type);

                        services.AddSingleton(new JobSchedule(new System.Guid(),
                            jobType: type,
                            jobName: item.JobName,
                            cronExpression: item.CronExpression));
                    }
                }
            }
            return services;
        }

        public static T AddConfigOptions<T>(this IServiceCollection services) where T : class
        {
            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();
            var appconfig = (T)Activator.CreateInstance(typeof(T));
            config.Bind("ConfigOptions", appconfig);
            services.AddSingleton(appconfig);
            services.Configure<T>(config.GetSection("ConfigOptions"));
            return appconfig;
        }
    }
}
