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
            
            builder.Property(e => e.Form).HasColumnName("FORMA");
            builder.Property(e => e.InstallmentsCount).HasColumnName("ILE_RAT");
            builder.Property(e => e.Contribution).HasColumnName("WKLAD");
            builder.Property(e => e.Composition).HasColumnName("SKLAD");
        }
    }
}