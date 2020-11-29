using Autofac;
using EKadry.Domain.Operators;
using EKadry.Domain.Workers;
using EKadry.Infrastructure.Configuration;
using EKadry.Infrastructure.Domain.Operators;
using EKadry.Infrastructure.Domain.Workers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EKadry.Infrastructure.Database
{
    public class DataAccessModule : Module
    {
        private readonly string _databaseConnectionString;

        public DataAccessModule(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
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