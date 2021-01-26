using System;
using EKadry.Application.Configuration.Commands;
using MediatR;

namespace EKadry.Application.Services.Contracts.ContractUpdate
{
    public class ContractUpdateCommand : CommandBase<Unit>
    {
        public Guid Id { get; }
        public DateTime EmployedAt { get; }
        public DateTime? EmployedEndAt { get; }
        public decimal BaseSalary { get; }
        public Guid IdJobPosition { get; }
        public int IdentifierZusNumber { get; }
        public bool IsSick { get; }
        public bool IsAnnuitant { get; }
        public bool IsPensioner { get; }
        public bool IsHealthy { get; }
        public bool IsLf { get; }
        public bool IsGebf { get; }
        public bool IsLeave { get; }
        public bool IsSickLeave { get; }
        public bool IsPkzp { get; }
        public decimal? WorkingTime { get; }
        public bool EntireInternship { get; }
        public bool ProfessionInternship { get; }
        public bool ServiceInternship { get; }
        public bool JubileeInternship { get; }

        public ContractUpdateCommand(
            Guid id,
            DateTime employedAt,
            DateTime? employedEndAt,
            decimal baseSalary,
            Guid idJobPosition,
            int identifierZusNumber,
            bool isSick,
            bool isAnnuitant,
            bool isPensioner,
            bool isHealthy,
            bool isLf,
            bool isGebf,
            bool isLeave,
            bool isSickLeave,
            bool isPkzp,
            decimal? workingTime,
            bool entireInternship,
            bool professionInternship,
            bool serviceInternship,
            bool jubileeInternship)
        {
            Id = id;
            EmployedAt = employedAt;
            EmployedEndAt = employedEndAt;
            BaseSalary = baseSalary;
            IdJobPosition = idJobPosition;
            IdentifierZusNumber = identifierZusNumber;
            IsSick = isSick;
            IsAnnuitant = isAnnuitant;
            IsPensioner = isPensioner;
            IsHealthy = isHealthy;
            IsLf = isLf;
            IsGebf = isGebf;
            IsLeave = isLeave;
            IsSickLeave = isSickLeave;
            IsPkzp = isPkzp;
            WorkingTime = workingTime;
            EntireInternship = entireInternship;
            ProfessionInternship = professionInternship;
            ServiceInternship = serviceInternship;
            JubileeInternship = jubileeInternship;
        }
    }
}