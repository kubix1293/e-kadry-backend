using System;
using EKadry.Domain.Pkzp.Position;

namespace EKadry.Domain.Pkzp.Schedule
{
    public class PkzpSchedule
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Period { get; set; }
        public Guid IdPeriod { get; set; }
        public Guid IdPkzpPosition { get; set; }
        public PkzpPosition PkzpPosition { get; set; }
        public bool IsClosed { get; set; }
    }
}