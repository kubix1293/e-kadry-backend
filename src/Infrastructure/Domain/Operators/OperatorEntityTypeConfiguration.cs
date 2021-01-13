using System;
using EKadry.Domain.Operators;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EKadry.Infrastructure.Domain.Operators
{
    internal sealed class OperatorEntityTypeConfiguration : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder.ToTable(SchemaNames.Operators);
            
            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.Active).HasColumnName("AKTW");
            builder.Property(e => e.FirstName).HasColumnName("IMIE");
            builder.Property(e => e.Login).HasColumnName("LOGIN");
            builder.Property(e => e.LastName).HasColumnName("NAZWISKO");
            builder.Property(e => e.Password).HasColumnName("PASSW");
            builder.Property(e => e.DeletedAt).HasColumnName("USUNIETY");
            builder.Property(e => e.CreatedAt).HasColumnName("UTWORZONY");
            builder.Property(e => e.UpdatedAt).HasColumnName("ZAKTUALIZOWANY");
            
            builder.HasQueryFilter(f => EF.Property<DateTime>(f, nameof(f.DeletedAt)) == null);
        }
    }
}