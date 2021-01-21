using EKadry.Domain.Pkzp;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EKadry.Infrastructure.Domain.Pkzp
{
    internal sealed class PkzpEntityTypeConfiguration : IEntityTypeConfiguration<EKadry.Domain.Pkzp.Pkzp>
    {
        public void Configure(EntityTypeBuilder<EKadry.Domain.Pkzp.Pkzp> builder)
        {
            builder.ToTable(SchemaNames.PkzpSchedule);
            
            builder.HasKey(b => b.Id);
            
            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.IdWorker).HasColumnName("ID_PRC");
            builder.Property(e => e.Balance).HasColumnName("SALDO");
            builder.Property(e => e.Debit).HasColumnName("DT");
            builder.Property(e => e.Credit).HasColumnName("CT");
            builder.Property(e => e.PkzpType).HasColumnName("RODZ").HasConversion(new EnumToNumberConverter<PkzpType, int>());
            builder.Property(e => e.IdPkzpPosition).HasColumnName("PKZP_POZ");
        }
    }
}