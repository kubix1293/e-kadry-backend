using System;

namespace EKadry.Domain.Pkzp.Position
{
    public class PkzpPosition
    {
        public Guid Id { get; set; }
        public PkzpPositionType Type { get; set; }
        public float Amount { get; set; }
        public Guid IdPeriod { get; set; }
        public Guid IdWorker { get; set; }
        
        
        public PkzpPosition()
        {
        }

        public static PkzpPosition CreatePkzpPosition()
        {
            return new PkzpPosition()
            {
                Id = Guid.NewGuid(),
            };
        }
    }
}