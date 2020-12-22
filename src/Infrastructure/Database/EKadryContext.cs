using EKadry.Domain.Contracts;
using EKadry.Domain.Operators;
using EKadry.Domain.Workers;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Database
{
    public class EKadryContext : DbContext
    {
        public DbSet<Operator> Operator { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<Contract> Contract { get; set; }

        public EKadryContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(EKadryContext).Assembly);
        }
    }
}