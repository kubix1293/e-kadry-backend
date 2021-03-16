using System;
using System.Collections.Generic;

namespace EKadry.Application.Services.Pkzp.PkzpSchedule
{
    public class PkzpScheduleDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public Guid IdPeriod { get; set; }
        public string Period { get; set; }
        public Guid IdPkzpPosition { get; set; }
        public bool IsClosed { get; set; }
    }
}