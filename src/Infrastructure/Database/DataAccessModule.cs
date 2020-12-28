using System.Reflection;
using Autofac;
using EKadry.Domain.Contracts;
using EKadry.Domain.Operators;
using EKadry.Domain.Workers;
using EKadry.Infrastructure.Configuration;
using EKadry.Infrastructure.Domain.Contracts;
using EKadry.Infrastructure.Domain.Operators;
using EKadry.Infrastructure.Domain.Workers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Serilog;
using Serilog.Extensions.Logging;
using Module = Autofac.Module;

namespace EKadry.Infrastructure.Database
{
    public class DataAccessModule : Module
    {
        private readonly string _databaseConnectionString;
        private readonly SerilogLoggerFactory _logger;

        public DataAccessModule(string databaseConnectionString, SerilogLoggerFactory logger)
        {
            _databaseConnectionString = databaseConnectionString;
            _logger = logger;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContractRepository>()
                .As<IContractRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<OperatorRepository>()
                .As<IOperatorRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<WorkerRepository>()
                .As<IWorkerRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<StronglyTypedIdValueConverterSelector>()
                .As<IValueConverterSelector>()
                .InstancePerLifetimeScope();

            builder.Register(c =>
                    new EKadryContext(
                        new DbContextOptionsBuilder<EKadryContext>()
                            .UseLoggerFactory(_logger)
                            .EnableSensitiveDataLogging()
                            .UseOracle(_databaseConnectionString)
                            .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                            .Options
                    )
                )
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}