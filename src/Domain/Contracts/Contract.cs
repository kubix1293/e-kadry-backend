using System;
using EKadry.Domain.Workers;

namespace EKadry.Domain.Contracts
{
    public class Contract : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime EmployedAt { get; set; }
        public DateTime? EmployedEndAt { get; set; }
        public decimal BaseSalary { get; set; }
        public Guid IdJobPosition { get; set; }
        public JobPosition.JobPosition JobPosition { get; set; }
        public Guid IdWorker { get; set; }
        public Worker Worker { get; set; }
        public int IdentifierZusNumber { get; set; }
        public bool IsSick { get; set; }
        public bool IsAnnuitant { get; set; }
        public bool IsPensioner { get; set; }
        public bool IsHealthy { get; set; }
        public bool IsLf { get; set; }
        public bool IsGebf { get; set; }
        public bool IsLeave { get; set; }
        public bool IsSickLeave { get; set; }
        public decimal? WorkingTime { get; set; }
        public int EntireInternship { get; set; }
        public int ProfessionInternship { get; set; }
        public int ServiceInternship { get; set; }
        public int JubileeInternship { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Contract()
        {
        }

        public static Contract CreateContract()
        {
            return new Contract()
            {
                Id = Guid.NewGuid(),
            };
        }

        public static Contract CreateContract(
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
            int? entireInternship,
            int? professionInternship,
            int? serviceInternship,
            int? jubileeInternship)
        {
            return new Contract()
            {
                Id = Guid.NewGuid(),
                EmployedAt = employedAt,
                EmployedEndAt = employedEndAt,
                BaseSalary = baseSalary,
                IdJobPosition = idJobPosition,
                IdWorker = idWorker,
                IdentifierZusNumber = identifierZusNumber,
                IsSick = isSick,
                IsAnnuitant = isAnnuitant,
                IsPensioner = isPensioner,
                IsHealthy = isHealthy,
                IsLf = isLf,
                IsGebf = isGebf,
                IsLeave = isLeave,
                IsSickLeave = isSickLeave,
                WorkingTime = workingTime,
                EntireInternship = entireInternship ?? 0,
                ProfessionInternship = professionInternship ?? 0,
                ServiceInternship = serviceInternship ?? 0,
                JubileeInternship = jubileeInternship ?? 0,
            };
        }
    }
}