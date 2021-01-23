using System;
using EKadry.Domain.Pkzp.Position;

namespace EKadry.Domain.Pkzp.Period
{
    public class Period
    {
        public Guid Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Days { get; set; }
        public int WorkingDays { get; set; }
        public int WorkingHours { get; set; }
        public PkzpPosition PkzpPosition { get; set; }

        public static Period Create(DateTime dateFrom, DateTime dateTo)
        {
            return new Period()
            {
                Id = Guid.NewGuid(),
                DateFrom = dateFrom,
                DateTo = dateTo
            };
        }
    }
}