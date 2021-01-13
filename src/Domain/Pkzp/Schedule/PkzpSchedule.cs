using System;

namespace EKadry.Domain.Pkzp.Schedule
{
    public class PkzpSchedule
    {
        public Guid Id { get; set; }
        
        public static PkzpSchedule CreatePkzpSchedule()
        {
            return new PkzpSchedule()
            {
                Id = Guid.NewGuid(),
            };
        }
    }
}