using System;
using EKadry.Domain.Pkzp.Period;

namespace EKadry.Application.Services.Pkzp.PkzpPositionFileQuery
{
    public class PkzpPositionFileQueryDto 
    {
        public Guid Id { get; set; }
        public EnumApi PkzpPositionType { get; set; }
        public decimal Amount { get; set; }
        public Period Period{ get; set; }
        public Guid IdWorker { get; set; }
        public Guid IdAncestorPkzpPosition { get; set; }
    }
}