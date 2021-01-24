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
    }
}