using System;

namespace EKadry.Domain.Pkzp.Schedule
{
    public class PkzpSchedule
    {
        public Guid Id { get; set; }
        public float Price { get; set; }
        public string Period { get; set; }
        public Guid IdPkzp { get; set; }
        public Pkzp Pkzp { get; set; }
        public bool IsClosed { get; set; }

        public static PkzpSchedule CreatePkzpSchedule()
        {
            return new PkzpSchedule()
            {
                Id = Guid.NewGuid(),
            };
        }
    }
}