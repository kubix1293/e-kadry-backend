using System;
using EKadry.Application.Configuration.Commands;

namespace EKadry.Application.Services.Contracts.ContractAdd
{
    public class ContractAddCommand : CommandBase<ContractDto>
    {
        public DateTime EmployedAt { get; }
        public DateTime? EmployedEndAt { get; }
        public decimal BaseSalary { get; }
        public Guid IdJobPosition { get; }
        public Guid IdWorker { get; }
        public int IdentifierZusNumber { get; }
        public bool IsSick { get; }
        public bool IsAnnuitant { get; }
        public bool IsPensioner { get; }
        public bool IsHealthy { get; }
        public bool IsLf { get; }
        public bool IsGebf { get; }
        public bool IsLeave { get; }
        public bool IsSickLeave { get; }
        public decimal? WorkingTime { get; }
        public bool EntireInternship { get; }
        public bool ProfessionInternship { get; }
        public bool ServiceInternship { get; }
        public bool JubileeInternship { get; }

        public ContractAddCommand(
            DateTime employedAt,
            DateTime? employedEndAt,
            decimal baseSalary,
            Guid idJobPosition,
            Guid idWorker,
            int identifierZusNumber,
            bool isSick,
            bool isAnnuitant,
            bool isPensioner,
            bool isHealthy,
            bool isLf,
            bool isGebf,
            bool isLeave,
            bool isSickLeave,
            decimal? workingTime,
            bool entireInternship,
            bool professionInternship,
            bool serviceInternship,
            bool jubileeInternship)
        {
            EmployedAt = employedAt;
            EmployedEndAt = employedEndAt;
            BaseSalary = baseSalary;
            IdJobPosition = idJobPosition;
            IdWorker = idWorker;
            IdentifierZusNumber = identifierZusNumber;
            IsSick = isSick;
            IsAnnuitant = isAnnuitant;
            IsPensioner = isPensioner;
            IsHealthy = isHealthy;
            IsLf = isLf;
            IsGebf = isGebf;
            IsLeave = isLeave;
            IsSickLeave = isSickLeave;
            WorkingTime = workingTime;
            EntireInternship = entireInternship;
            ProfessionInternship = professionInternship;
            ServiceInternship = serviceInternship;
            JubileeInternship = jubileeInternship;
        }
    }
}