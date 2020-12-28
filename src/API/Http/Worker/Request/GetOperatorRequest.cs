using System;
using EKadry.Domain.Workers;

namespace EKadry.API.Http.Worker.Request
{
    public class GetWorkerRequest
    {
        public Guid Guid { get; set; }
    }
}