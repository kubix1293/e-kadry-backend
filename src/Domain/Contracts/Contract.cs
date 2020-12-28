using System;
using System.Text.Json.Serialization;
using EKadry.Domain.Workers;

namespace EKadry.Domain.Contracts
{
    public class Contract : Entity, IAggregateRoot
    {
        public ContractId Id { get; set; }
        public DateTime EmployedAt { get; set; }

        public DateTime? EmployedEndAt { get; set; }

        // public decimal BaseSalary { get; set; }
        // public int IdJobPosition { get; set; }
        // public int IdContractType { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public WorkerId IdWorker { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Worker Worker { get; set; }
        public int IdentifierZusNumber { get; set; }
        public bool IsSick { get; set; }
        public bool IsAnnuitant { get; set; }
        public bool IsPensioner { get; set; }
        public bool IsHealtly { get; set; }
        public bool IsLf { get; set; }
        public bool IsGebf { get; set; }
        public bool IsLeave { get; set; }
        public bool IsSickLeave { get; set; }
        public decimal? WorkingTime { get; set; }
        public int EntireInternship { get; set; }
        public int ProffesionInternship { get; set; }
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
                Id = new ContractId(Guid.NewGuid()),
            };
        }
    }
    
    public class Contract2 : Entity, IAggregateRoot
    {
        public ContractId Id { get; set; }
        public DateTime EmployedAt { get; set; }

        public DateTime? EmployedEndAt { get; set; }

        // public decimal BaseSalary { get; set; }
        // public int IdJobPosition { get; set; }
        // public int IdContractType { get; set; }
        public int IdentifierZusNumber { get; set; }
        public bool IsSick { get; set; }
        public bool IsAnnuitant { get; set; }
        public bool IsPensioner { get; set; }
        public bool IsHealtly { get; set; }
        public bool IsLf { get; set; }
        public bool IsGebf { get; set; }
        public bool IsLeave { get; set; }
        public bool IsSickLeave { get; set; }
        public decimal? WorkingTime { get; set; }
        public int EntireInternship { get; set; }
        public int ProffesionInternship { get; set; }
        public int ServiceInternship { get; set; }
        public int JubileeInternship { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Contract2()
        {
        }

        public static Contract CreateContract()
        {
            return new Contract()
            {
                Id = new ContractId(Guid.NewGuid()),
            };
        }
    }
}