using EKadry.Domain.Contracts.JobPosition;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EKadry.Infrastructure.Domain.Contracts
{
    internal sealed class JobPositionEntityTypeConfiguration : IEntityTypeConfiguration<JobPosition>
    {
        public void Configure(EntityTypeBuilder<JobPosition> builder)
        {
            builder.ToTable(SchemaNames.JobPostions);

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.Name).HasColumnName("NAZWA");
            builder.Property(e => e.GusCode).HasColumnName("KOD_GUS");
        }
    }
}