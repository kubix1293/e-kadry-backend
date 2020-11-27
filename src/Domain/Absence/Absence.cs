using System;

namespace EKadry.Domain.Absence
{
    public class Absence
    {
        public decimal Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal IdTypobec { get; set; }
        public decimal IdPrc { get; set; }
        public decimal IdUmp { get; set; }
        public string Zada { get; set; }
    }
}
