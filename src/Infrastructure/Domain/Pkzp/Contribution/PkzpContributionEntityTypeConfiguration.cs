using EKadry.Domain.Pkzp.Contributions;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EKadry.Infrastructure.Domain.Pkzp.Contribution
{
    internal sealed class PkzpContributionEntityTypeConfiguration : IEntityTypeConfiguration<PkzpContribution>
    {
        public void Configure(EntityTypeBuilder<PkzpContribution> builder)
        {
            builder.ToTable(SchemaNames.PkzpContributions);

            builder.HasKey(b => b.Id);
            
            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.IdWorker).HasColumnName("ID_PRC");
            builder.Property(e => e.Amount).HasColumnName("SKLAD");
            builder.Property(e => e.UpdatedAt).HasColumnName("DAKT");
            
            builder.HasOne(d => d.Worker)
                .WithMany(n => n.PkzpContributions)
                .HasForeignKey(p => p.IdWorker);
        }
    }
}