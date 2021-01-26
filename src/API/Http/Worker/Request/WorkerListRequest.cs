using System;

namespace EKadry.API.Http.Worker.Request
{
    public class WorkerListRequest : ListRequest
    {
        public bool? ShowInactiveContracts { get; set; }
        public bool? HasPkzp { get; set; }
        public Guid? JobPosition { get; set; }
    }
}