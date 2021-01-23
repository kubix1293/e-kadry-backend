using System;

namespace EKadry.Application.Services.Periods.PeriodList
{
    public class PeriodListDto
    {
        public Guid Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Days { get; set; }
        public int WorkingDays { get; set; }
        public int WorkingHours { get; set; }
    }
}