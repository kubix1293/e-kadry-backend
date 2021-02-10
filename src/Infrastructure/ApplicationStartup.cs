using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.CommonServiceLocator;
using AutoMapper;
using CommonServiceLocator;
using EKadry.Application.Configuration;
using EKadry.Infrastructure.Auth;
using EKadry.Infrastructure.Configuration;
using EKadry.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Extensions.Logging;

namespace EKadry.Infrastructure
{
    public static class ApplicationStartup
    {
        public static IServiceProvider Initialize(
            IServiceCollection services,
            string connectionString,
            string secretKey,
            int tokenExpire,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger
        )
        {
            var moduleLogger = logger.ForContext("Module", "Application");
            services.AddSingleton(ConfigureMapper());
            
            return ConfigureCompositorRoot(
                services,
                connectionString,
                secretKey,
                tokenExpire,
                executionContextAccessor,
                moduleLogger
            );
        }

        private static IServiceProvider ConfigureCompositorRoot(
            IServiceCollection services,
            string connectionString,
            string secretKey,
            int tokenExpire,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(services);

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "Application")));
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, new SerilogLoggerFactory(logger)));
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new AuthModule(secretKey, tokenExpire));

            containerBuilder.RegisterInstance(executionContextAccessor);

            var buildContainer = containerBuilder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(buildContainer));

            var serviceProvider = new AutofacServiceProvider(buildContainer);

            CompositionRoot.SetContainer(buildContainer);

            return serviceProvider;
        }
        
        private static IMapper ConfigureMapper()
        {
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new AutoMapperProfiles());
            });

            return mapperConfig.CreateMapper();
        }
    }
}