using EKadry.Infrastructure.Configuration;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EKadry.Infrastructure.Domain.Pkzp.PkzpSchedule
{
    internal sealed class PkzpScheduleEntityTypeConfiguration : IEntityTypeConfiguration<EKadry.Domain.Pkzp.Schedule.PkzpSchedule>
    {
        public void Configure(EntityTypeBuilder<EKadry.Domain.Pkzp.Schedule.PkzpSchedule> builder)
        {
            builder.ToTable(SchemaNames.PkzpSchedule);
            
            builder.HasKey(b => b.Id);
            
            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.Price).HasColumnName("KWOT").HasColumnType("FLOAT(15)");
            builder.Property(e => e.Period).HasColumnName("OKRES");
            builder.Property(e => e.IdPeriod).HasColumnName("ID_OKS");
            builder.Property(e => e.IdPkzpPosition).HasColumnName("ID_PKZP");
            builder.Property(e => e.IsClosed).HasColumnName("ZAMK").HasConversion(new IntToBooleanConverter());
            
            builder.HasOne(d => d.PkzpPosition)
                .WithMany(n => n.PkzpSchedules)
                .HasForeignKey(p => p.IdPkzpPosition);
        }
    }
}