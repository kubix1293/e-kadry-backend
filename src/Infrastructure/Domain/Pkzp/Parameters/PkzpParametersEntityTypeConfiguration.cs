using EKadry.Domain.Pkzp.Parameters;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EKadry.Infrastructure.Domain.Pkzp.Parameters
{
    internal sealed class PkzpParametersEntityTypeConfiguration : IEntityTypeConfiguration<PkzpParameters>
    {
        public void Configure(EntityTypeBuilder<PkzpParameters> builder)
        {
            builder.ToTable(SchemaNames.PkzpParameters);

            builder.HasNoKey();
            
            builder.Property(e => e.Form).HasColumnName("FORMA").HasColumnType("NUMBER(1)");
            builder.Property(e => e.InstallmentsCount).HasColumnName("ILE_RAT").HasColumnType("NUMBER(2)");
            builder.Property(e => e.Entry).HasColumnName("WPIS").HasColumnType("FLOAT(10)");
            builder.Property(e => e.MinComposition).HasColumnName("SKLAD_MIN").HasColumnType("FLOAT(10)");
            builder.Property(e => e.MaxComposition).HasColumnName("SKLAD_MAX").HasColumnType("FLOAT(10)");
            builder.Property(e => e.MaxAmount).HasColumnName("KWOT_MAX").HasColumnType("FLOAT(10)");
            builder.Property(e => e.MinContribution).HasColumnName("WKLAD_MIN").HasColumnType("FLOAT(10)");
        }
    }
}