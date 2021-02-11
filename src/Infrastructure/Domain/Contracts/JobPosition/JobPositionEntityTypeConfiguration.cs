using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EKadry.Infrastructure.Domain.Contracts.JobPosition
{
    internal sealed class JobPositionEntityTypeConfiguration : IEntityTypeConfiguration<EKadry.Domain.Contracts.JobPosition.JobPosition>
    {
        public void Configure(EntityTypeBuilder<EKadry.Domain.Contracts.JobPosition.JobPosition> builder)
        {
            builder.ToTable(SchemaNames.JobPositions);

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.Name).HasColumnName("NAZWA");
            builder.Property(e => e.GusCode).HasColumnName("KOD_GUS");
        }
    }
}