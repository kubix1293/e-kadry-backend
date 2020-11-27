using EKadry.Domain.Operators;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Database
{
    public class EKadryContext : DbContext
    {
        public DbSet<Operator> Operator { get; set; }

        public EKadryContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(EKadryContext).Assembly);
        }
    }
}