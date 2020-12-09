using System;
using EKadry.Domain.Workers;
using EKadry.Infrastructure.Configuration;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EKadry.Infrastructure.Domain.Workers
{
    internal sealed class WorkerEntityTypeConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable(SchemaNames.Workers);
            
            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("ID").HasConversion(new TypedIdValueToByteConverter<WorkerId>());
            builder.Property(e => e.FirstName).HasColumnName("IMIE");
            builder.Property(e => e.LastName).HasColumnName("NAZWISKO");
            builder.Property(e => e.Birthday).HasColumnName("DTUR");
            builder.Property(e => e.CityOfBirthday).HasColumnName("MISC_URO");
            builder.Property(e => e.Pesel).HasColumnName("PESEL");
            builder.Property(e => e.DocumentType).HasColumnName("DOK_TYP").HasConversion(new EnumToNumberConverter<DocumentType, int>());
            builder.Property(e => e.DocumentNumber).HasColumnName("NR_DOK");
            builder.Property(e => e.Gender).HasColumnName("PLEC").HasConversion(new EnumToNumberConverter<Gender, int>());
            builder.Property(e => e.IdCity).HasColumnName("ID_MISC");
            builder.Property(e => e.Street).HasColumnName("ULICA");
            builder.Property(e => e.PropertyNumber).HasColumnName("NR_DOM");
            builder.Property(e => e.ApartmentNumber).HasColumnName("NR_LOK");
            builder.Property(e => e.ActNumber).HasColumnName("NR_AKT");
            builder.Property(e => e.MotherName).HasColumnName("IMIE_MAT");
            builder.Property(e => e.FatherName).HasColumnName("IMIE_OJC");
            builder.Property(e => e.Phone).HasColumnName("TELE");
            builder.Property(e => e.OperatorId).HasColumnName("ID_OPER");
            builder.Property(e => e.DeletedAt).HasColumnName("USUNIETY");
            builder.Property(e => e.CreatedAt).HasColumnName("UTWORZONY");
            builder.Property(e => e.UpdatedAt).HasColumnName("ZAKTUALIZOWANY");
            
            builder.HasQueryFilter(f => EF.Property<DateTime>(f, nameof(f.DeletedAt)) == null);
        }
    }
}