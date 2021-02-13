using EKadry.Domain.Pkzp.Position;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EKadry.Infrastructure.Domain.Pkzp.PkzpPosition
{
    internal sealed class PkzpPositionEntityTypeConfiguration : IEntityTypeConfiguration<EKadry.Domain.Pkzp.Position.PkzpPosition>
    {
        public void Configure(EntityTypeBuilder<EKadry.Domain.Pkzp.Position.PkzpPosition> builder)
        {
            builder.ToTable(SchemaNames.PkzpPositions);
            
            builder.HasKey(b => b.Id);
            
            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.PkzpPositionType).HasColumnName("RODZ").HasConversion(new EnumToNumberConverter<PkzpPositionType, int>());
            builder.Property(e => e.Amount).HasColumnName("KWOT").HasColumnType("FLOAT(10)");
            builder.Property(e => e.IdPeriod).HasColumnName("ID_OKS");
            builder.Property(e => e.IdWorker).HasColumnName("ID_PRC");
            builder.Property(e => e.IdAncestorPkzpPosition).HasColumnName("PKZP_POZ").IsRequired(false);
            builder.Property(e => e.IsClosed).HasColumnName("ZAMK").HasColumnType("NUMBER(1)");
            builder.Property(e => e.CreatedAt).HasColumnName("UTWORZONY");

            builder.HasOne(d => d.Worker)
                .WithMany(n => n.PkzpPositions)
                .HasForeignKey(p => p.IdWorker)
                .IsRequired(false);
            
            builder.HasOne(d => d.AncestorPkzpPosition)
                .WithOne()
                .HasForeignKey<EKadry.Domain.Pkzp.Position.PkzpPosition>(x => x.IdAncestorPkzpPosition)
                .IsRequired(false);
        }
    }
}