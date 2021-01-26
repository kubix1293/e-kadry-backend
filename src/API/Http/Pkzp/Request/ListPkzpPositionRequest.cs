using System;

namespace EKadry.API.Http.Pkzp.Request
{
    public class ListPkzpPositionRequest : ListRequest
    {
        public Guid WorkerId { get; set; }
    }
}