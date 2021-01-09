using System;
using System.Collections.Generic;

namespace EKadry.Domain.Contracts.JobPosition
{
    public class JobPosition
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int GusCode { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}