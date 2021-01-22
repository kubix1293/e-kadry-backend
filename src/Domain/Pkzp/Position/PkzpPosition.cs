using System;
using EKadry.Domain.Workers;

namespace EKadry.Domain.Pkzp.Position
{
    public class PkzpPosition
    {
        public Guid Id { get; set; }
        public PkzpPositionType PkzpPositionType { get; set; }
        public decimal Amount { get; set; }
        public Guid IdPeriod { get; set; }
        public Period.Period Period{ get; set; }
        public Guid IdWorker { get; set; }
        public Worker Worker { get; set; }
        public Guid IdAncestorPkzpPosition { get; set; }
        public PkzpPosition AncestorPkzpPosition { get; set; }
        
        public static PkzpPosition CreatePkzpPosition()
        {
            return new PkzpPosition()
            {
                Id = Guid.NewGuid(),
            };
        }
    }
}