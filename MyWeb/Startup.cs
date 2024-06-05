using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyWeb.BAL;
using MyWeb.BAL.Service;
using MyWeb.DAL;
using MyWeb.DAL.Data;
using MyWeb.Dequeues;
using MyWeb.Quartz;
using System.Collections.Generic;
using System.IO.Compression;
using System.Reflection;

namespace MyWeb
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();
            services.Configure<RabbitMQOptions>(config.GetSection("RabbitMQConnection"));
            services.AddSingleton<RabbitMQClientBase>();
            services.AddSingleton<RabbitChannelProcess>();

            var appconfig = services.AddConfigOptions<ConfigOptions>();
            services.AddControllers();
            services.AddHttpClient();
            services.AddRepositories();
            services.AddServices();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUDAspNetCore5WebAPI", Version = "v1" });
            });
            services.AddQuartz();
            services.AddHostedService<QuartzHostedService>();
            services.AddCors(options =>
            {
                options.AddPolicy("MemOrigins",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            #region Enable Response Compression
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                IEnumerable<string> MimeTypes = new[]
                {
                     "application/javascript",
                     "application/json",
                     "application/xml",
                     "text/css",
                     "text/plain",
                     "text/html",
                     "text/json",
                     "text/xml"
                };
                options.MimeTypes = MimeTypes;
                options.EnableForHttps = true;
            });
            #endregion
            services.AddMemoryCache();
            services.AddSingleton<RabbitMQServices>();
            services.AddSingleton<IHostedService, RabbitMQServices>(
            serviceProvider => serviceProvider.GetService<RabbitMQServices>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUDAspNetCore5WebAPI v1"));
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MemOrigins");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}