using System;
using System.Collections.Generic;
using EKadry.Domain.Operators;
using EKadry.Domain.Workers;

namespace EKadry.Application.Services.Contracts.ContractDetail
{
    public class ContractDetailDto
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
    }
}