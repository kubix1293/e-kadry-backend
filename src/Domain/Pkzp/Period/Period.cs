using System;
using EKadry.Domain.Pkzp.Position;

namespace EKadry.Domain.Pkzp.Period
{
    public class Period
    {
        public Guid Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public PkzpPosition PkzpPosition { get; set; }
    }
}