using System;
using EKadry.Domain.Workers;

namespace EKadry.Domain.Pkzp.Position
{
    public class PkzpPosition
    {
        public Guid Id { get; set; }
        public PkzpPositionType PkzpPositionType { get; set; }
        public float Amount { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Guid IdWorker { get; set; }
        public Worker Worker { get; set; }
        
        public static PkzpPosition CreatePkzpPosition()
        {
            return new PkzpPosition()
            {
                Id = Guid.NewGuid(),
            };
        }
    }
}