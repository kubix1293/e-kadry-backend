using System;
using EKadry.Domain.Contracts;
using EKadry.Infrastructure.Configuration;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EKadry.Infrastructure.Domain.Contracts
{
    internal sealed class ContractEntityTypeConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable(SchemaNames.Contracts);
            
            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("ID").HasConversion(new TypedIdValueToByteConverter<ContractId>());
            builder.Property(e => e.EmployedAt).HasColumnName("DTZAW");
            builder.Property(e => e.EmployedEndAt).HasColumnName("DTROZ");
            // builder.Property(e => e.BaseSalary).HasColumnName("ZASAD");
            // builder.Property(e => e.IdJobPosition).HasColumnName("ID_STANOW");
            // builder.Property(e => e.IdContractType).HasColumnName("ID_TYPUM");
            builder.Property(e => e.IdWorker).HasColumnName("ID_PRC");
            builder.Property(e => e.IdentifierZusNumber).HasColumnName("NR_TYT_ZUS");
            builder.Property(e => e.IsSick).HasColumnName("CZY_CHOR").HasConversion(new IntToBooleanConverter());
            builder.Property(e => e.IsAnnuitant).HasColumnName("CZY_REN").HasConversion(new IntToBooleanConverter());
            builder.Property(e => e.IsPensioner).HasColumnName("CZY_EMER").HasConversion(new IntToBooleanConverter());
            builder.Property(e => e.IsHealtly).HasColumnName("CZY_ZDROW").HasConversion(new IntToBooleanConverter());
            builder.Property(e => e.IsLf).HasColumnName("CZY_FP").HasConversion(new IntToBooleanConverter());
            builder.Property(e => e.IsGebf).HasColumnName("CZY_FGSP").HasConversion(new IntToBooleanConverter());
            builder.Property(e => e.IsLeave).HasColumnName("CZY_URLOP").HasConversion(new IntToBooleanConverter());
            builder.Property(e => e.IsSickLeave).HasColumnName("CZY_AB_CHOR").HasConversion(new IntToBooleanConverter());
            builder.Property(e => e.WorkingTime).HasColumnName("NRM_CZAS_PRAC");
            builder.Property(e => e.EntireInternship).HasColumnName("STOG");
            builder.Property(e => e.ProffesionInternship).HasColumnName("STZW");
            builder.Property(e => e.ServiceInternship).HasColumnName("STWS");
            builder.Property(e => e.JubileeInternship).HasColumnName("STJB");
            builder.Property(e => e.DeletedAt).HasColumnName("USUNIETY");
            builder.Property(e => e.CreatedAt).HasColumnName("UTWORZONY");
            builder.Property(e => e.UpdatedAt).HasColumnName("ZAKTUALIZOWANY");

            // builder.HasOne(d => d.Worker)
            //     .WithMany(p => p.Contracts)
            //     .IsRequired(false)
            //     .HasForeignKey(p => p.IdWorker)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("UMOWY_PRACOWNICY_FK");

            builder.HasQueryFilter(f => EF.Property<DateTime>(f, nameof(f.DeletedAt)) == null);
        }
    }
}