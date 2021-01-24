using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EKadry.Domain;
using EKadry.Domain.Contracts;
using EKadry.Domain.Contracts.JobPosition;
using EKadry.Domain.Operators;
using EKadry.Domain.Pkzp;
using EKadry.Domain.Pkzp.Parameters;
using EKadry.Domain.Pkzp.Period;
using EKadry.Domain.Pkzp.Position;
using EKadry.Domain.Workers;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Database
{
    public class EKadryContext : DbContext
    {
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<JobPosition> JobPosition { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<PkzpParameters> PkzpParameters { get; set; }
        public virtual DbSet<PkzpPosition> PkzpPositions { get; set; }
        public virtual DbSet<Pkzp> Pkzp { get; set; }

        public EKadryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(EKadryContext).Assembly);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity) entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity) entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity) entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity) entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}