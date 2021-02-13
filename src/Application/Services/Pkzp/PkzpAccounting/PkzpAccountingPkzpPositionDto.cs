using System;
using System.Collections.Generic;
using EKadry.Domain.Pkzp.Position;

namespace EKadry.Application.Services.Pkzp.PkzpAccounting
{
    public class PkzpAccountingPkzpPositionDto
    {
        public Guid Id { get; set; }
        public PkzpPositionType PkzpPositionType { get; set; }
        public decimal Amount { get; set; }
        public ICollection<PkzpAccountingPkzpScheduleDto> PkzpSchedules { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}