using System;
using EKadry.Domain.Contracts.JobPosition;

namespace EKadry.Application.Services.Contracts.ContractList
{
    public class ContractListDto
    {
        public Guid Id { get; set; }
        public DateTime EmployedAt { get; set; }
        public DateTime? EmployedEndAt { get; set; }
        public decimal BaseSalary { get; set; }
        public Guid IdJobPosition { get; set; }
        public JobPosition JobPosition { get; set; }
        public Guid IdWorker { get; set; }
        public WorkerDetailDto Worker { get; set; }
        public int IdentifierZusNumber { get; set; }
        public bool IsSick { get; set; }
        public bool IsAnnuitant { get; set; }
        public bool IsPensioner { get; set; }
        public bool IsHealtly { get; set; }
        public bool IsLf { get; set; }
        public bool IsGebf { get; set; }
        public bool IsLeave { get; set; }
        public bool IsSickLeave { get; set; }
        public bool IsPkzp { get; set; }
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