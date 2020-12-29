using System;
using EKadry.Domain.Workers;

namespace EKadry.Domain.Contracts
{
    public class Contract
    {
        public Guid Id { get; set; }
        public DateTime EmployedAt { get; set; }

        public DateTime? EmployedEndAt { get; set; }

        // public decimal BaseSalary { get; set; }
        // public int IdJobPosition { get; set; }
        // public int IdContractType { get; set; }
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
    }
}