using System;

namespace EKadry.API.Http.Pkzp.Request
{
    public class PkzpScheduleRequest : ListRequest
    {
        public Guid PkzpPositionId { get; set; }
    }
}