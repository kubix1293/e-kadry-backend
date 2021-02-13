using System;
using EKadry.Domain.Workers;

namespace EKadry.Domain.Pkzp.Contributions
{
    public class PkzpContribution
    {
        public Guid Id { get; set; }
        public Guid IdWorker { get; set; }
        public Worker Worker { get; set; }
        public decimal Amount { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}