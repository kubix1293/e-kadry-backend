using System;
using System.Collections.Generic;

namespace EKadry.Application.Services.Pkzp.PkzpAccounting
{
    public class PkzpAccountingDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<PkzpAccountingPkzpPositionDto> PkzpPositions { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}