using System;

namespace EKadry.Application.Services.Pkzp.PkzpAccounting
{
    public class PkzpAccountingPkzpScheduleDto 
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Period { get; set; }
        public bool IsClosed { get; set; }
    }
}