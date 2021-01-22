using System;
using EKadry.Domain.Pkzp;

namespace EKadry.API.Http.Pkzp.Request
{
    public class CreatePkzpRequest
    {
        public PkzpType PkzpType { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Guid WorkerId { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentsCount { get; set; }
        public decimal InstallmentAmount { get; set; }
    }
}