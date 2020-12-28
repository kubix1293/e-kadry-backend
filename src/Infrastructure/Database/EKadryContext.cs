using EKadry.Domain.Contracts;
using EKadry.Domain.Operators;
using EKadry.Domain.Workers;
using EKadry.Infrastructure.Domain.Contracts;
using EKadry.Infrastructure.Domain.Operators;
using EKadry.Infrastructure.Domain.Workers;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Database
{
    public class EKadryContext : DbContext
    {
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }

        public EKadryContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.ApplyConfigurationsFromAssembly(typeof(EKadryContext).Assembly);
            builder.ApplyConfiguration(new ContractEntityTypeConfiguration());
            builder.ApplyConfiguration(new WorkerEntityTypeConfiguration());
            builder.ApplyConfiguration(new OperatorEntityTypeConfiguration());
        }
    }
}