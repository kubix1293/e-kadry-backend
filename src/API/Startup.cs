using System;
using EKadry.API.Configuration;
using EKadry.Application.Configuration;
using EKadry.Infrastructure;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.AspNetCore.HttpOverrides;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EKadry.API
{
    public class Startup
    {
        private readonly IHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private static ILogger _logger;

        public Startup(IHostEnvironment env)
        {
            _env = env;
            _logger = ConfigureLogger();
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .Build();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.CorsConfigure();
            services.ConfigureProblemDetails(_env.IsProduction());
            services.AddSwaggerDocumentation();

            services.AddHttpContextAccessor();
            services.AuthenticationConfigure(_configuration.GetSection("AppSettings").GetSection("JWT").GetValue<string>("SecretKey"));
            
            var serviceProvider = services.BuildServiceProvider();

            IExecutionContextAccessor executionContextAccessor = new ExecutionContextAccessor(serviceProvider.GetService<IHttpContextAccessor>());

            return ApplicationStartup.Initialize(
                services,
                _configuration.GetValue<string>("ConnectionString"),
                _configuration.GetSection("AppSettings").GetSection("JWT").GetValue<string>("SecretKey"),
                _configuration.GetSection("AppSettings").GetSection("JWT").GetValue<int>("ExpireMinutes"),
                executionContextAccessor,
                _logger
            );
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseProblemDetails();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseCors(env.EnvironmentName);
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            if (env.IsDevelopment())
            {
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