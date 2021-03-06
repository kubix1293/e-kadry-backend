﻿using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EKadry.Infrastructure.Domain.Pkzp.Period
{
    internal sealed class PeriodEntityTypeConfiguration : IEntityTypeConfiguration<EKadry.Domain.Pkzp.Period.Period>
    {
        public void Configure(EntityTypeBuilder<EKadry.Domain.Pkzp.Period.Period> builder)
        {
            builder.ToTable(SchemaNames.Periods);
            
            builder.HasKey(b => b.Id);
            
            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.DateFrom).HasColumnName("DTOD");
            builder.Property(e => e.DateTo).HasColumnName("DTDO");
            builder.Property(e => e.Days).HasColumnName("DNI_KAL");
            builder.Property(e => e.WorkingDays).HasColumnName("DNI_ROB");
            builder.Property(e => e.WorkingHours).HasColumnName("NORMA");
            
            builder.HasOne(d => d.PkzpSchedule)
                .WithOne(n => n.Period)
                .HasForeignKey<EKadry.Domain.Pkzp.Schedule.PkzpSchedule>(p => p.IdPeriod);
            
            builder.HasOne(d => d.PkzpPosition)
                .WithOne(n => n.Period)
                .HasForeignKey<EKadry.Domain.Pkzp.Position.PkzpPosition>(p => p.IdPeriod);
        }
    }
}