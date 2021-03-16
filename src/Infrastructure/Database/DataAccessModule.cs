using Autofac;
using EKadry.Domain.Contracts;
using EKadry.Domain.Contracts.JobPosition;
using EKadry.Domain.Operators;
using EKadry.Domain.Pkzp;
using EKadry.Domain.Pkzp.Parameters;
using EKadry.Domain.Pkzp.Period;
using EKadry.Domain.Pkzp.Position;
using EKadry.Domain.Pkzp.Schedule;
using EKadry.Domain.Workers;
using EKadry.Infrastructure.Domain.Contracts;
using EKadry.Infrastructure.Domain.Contracts.JobPosition;
using EKadry.Infrastructure.Domain.Operators;
using EKadry.Infrastructure.Domain.Pkzp;
using EKadry.Infrastructure.Domain.Pkzp.Parameters;
using EKadry.Infrastructure.Domain.Pkzp.Period;
using EKadry.Infrastructure.Domain.Pkzp.PkzpPosition;
using EKadry.Infrastructure.Domain.Pkzp.PkzpSchedule;
using EKadry.Infrastructure.Domain.Workers;
using Microsoft.EntityFrameworkCore;
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
            builder.RegisterType<JobPositionRepository>()
                .As<IJobPositionRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PkzpRepository>()
                .As<IPkzpRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PkzpPositionRepository>()
                .As<IPkzpPositionRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PeriodRepository>()
                .As<IPeriodRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PkzpParametersRepository>()
                .As<IPkzpParametersRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PkzpScheduleRepository>()
                .As<IPkzpScheduleRepository>()
                .InstancePerLifetimeScope();
            
            builder.Register(c =>
                    new EKadryContext(
                        new DbContextOptionsBuilder<EKadryContext>()
                            .UseLoggerFactory(_logger)
                            .UseOracle(_databaseConnectionString)
                            .Options
                    )
                )
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}