using System;
using System.Net;
using AutoMapper;
using EKadry.API.Configuration;
using EKadry.Application.Configuration;
using EKadry.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.AspNetCore.HttpOverrides;

namespace EKadry.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private static ILogger _logger;

        public Startup(IHostEnvironment env)
        {
            _logger = ConfigureLogger();
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .Build();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerDocumentation();

            services.Configure<ForwardedHeadersOptions>(options => { options.KnownProxies.Add(IPAddress.Parse("0.0.0.0")); });

            services.AddHttpContextAccessor();
            services.JwtServiceConfigure(_configuration.GetSection("AppSettings").GetSection("JWT"));

            var serviceProvider = services.BuildServiceProvider();

            IExecutionContextAccessor executionContextAccessor = new ExecutionContextAccessor(serviceProvider.GetService<IHttpContextAccessor>());

            return ApplicationStartup.Initialize(
                services,
                _configuration["ConnectionString"],
                executionContextAccessor,
                _logger
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            // app.UseAuthentication();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
            }
        }

        private static ILogger ConfigureLogger()
        {
            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(
                    "logs/logs.log",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{Context}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            logger.Information("Logger configured");

            return logger;
        }
    }
}