using System;
using System.Collections.Generic;
using EKadry.Domain.Pkzp.Schedule;
using EKadry.Domain.Workers;

namespace EKadry.Domain.Pkzp.Position
{
    public class PkzpPosition
    {
        public Guid Id { get; set; }
        public PkzpPositionType PkzpPositionType { get; set; }
        public decimal Amount { get; set; }
        public Guid IdPeriod { get; set; }
        public Period.Period Period { get; set; }
        public Guid IdWorker { get; set; }
        public Worker Worker { get; set; }
        public Guid? IdAncestorPkzpPosition { get; set; }
        public DateTime CreatedAt { get; set; }
        public PkzpPosition AncestorPkzpPosition { get; set; }
        public IEnumerable<Pkzp> Pkzp { get; set; }
        public bool IsClosed { get; set; }
        public IEnumerable<PkzpSchedule> PkzpSchedules { get; set; }

        public static PkzpPosition Create()
        {
            return new PkzpPosition()
            {
                Id = Guid.NewGuid(),
            };
        }
    }
}