using System;

namespace EKadry.API.Http.Pkzp.Request
{
    public class PkzpAccountingRequest : ListRequest
    {
        public Guid PeriodId { get; set; }
    }
}