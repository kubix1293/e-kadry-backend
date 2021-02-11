using System;

namespace EKadry.Application.Services.Pkzp.PkzpSummary
{
    public class PkzpSummaryDto
    {
        public Guid Id { get; set; }
        public Guid IdWorker { get; set; }
        public decimal Balance { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Repayment { get; set; }
        public EnumApi PkzpType { get; set; }
        public bool Closed { get; set; }
    }
}