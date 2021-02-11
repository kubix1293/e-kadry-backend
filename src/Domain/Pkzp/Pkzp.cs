using System;
using EKadry.Domain.Pkzp.Position;
using EKadry.Domain.Workers;

namespace EKadry.Domain.Pkzp
{
    public class Pkzp
    {
        public Guid Id { get; set; }
        public Guid IdWorker { get; set; }
        public Worker Worker { get; set; }
        public decimal Balance { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public PkzpType PkzpType { get; set; }
        public bool Closed { get; set; }
        public Guid IdPkzpPosition { get; set; }
        public PkzpPosition PkzpPosition { get; set; }
    }
}