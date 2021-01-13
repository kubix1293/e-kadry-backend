using System;

namespace EKadry.API.Http.Contract.Request
{
    public class AddContractRequest
    {
        public DateTime EmployedAt { get; set; }
        public DateTime? EmployedEndAt { get; set; }
        public decimal BaseSalary { get; set; }
        public Guid IdJobPosition { get; set; }
        public Guid IdWorker { get; set; }
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
        public bool EntireInternship { get; set; }
        public bool ProfessionInternship { get; set; }
        public bool ServiceInternship { get; set; }
        public bool JubileeInternship { get; set; }
    }
}