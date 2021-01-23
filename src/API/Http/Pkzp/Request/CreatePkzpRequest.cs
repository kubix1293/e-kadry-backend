using System;
using EKadry.Domain.Pkzp.Position;

namespace EKadry.API.Http.Pkzp.Request
{
    public class CreatePkzpRequest
    {
        public PkzpPositionType PkzpPositionType { get; set; }
        public Guid PeriodId { get; set; }
        public Guid WorkerId { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentsCount { get; set; }
        public decimal InstallmentAmount { get; set; }
    }
}