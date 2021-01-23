using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EKadry.Infrastructure.Domain.Pkzp.Period
{
    internal sealed class PeriodEntityTypeConfiguration : IEntityTypeConfiguration<EKadry.Domain.Pkzp.Period.Period>
    {
        public void Configure(EntityTypeBuilder<EKadry.Domain.Pkzp.Period.Period> builder)
        {
            builder.ToTable(SchemaNames.Period);
            
            builder.HasKey(b => b.Id);
            
            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.DateFrom).HasColumnName("DTOD");
            builder.Property(e => e.DateTo).HasColumnName("DTDO");
            
            builder.HasOne(d => d.PkzpPosition)
                .WithOne(n => n.Period)
                .HasForeignKey<EKadry.Domain.Pkzp.Position.PkzpPosition>(p => p.IdPeriod);
        }
    }
}