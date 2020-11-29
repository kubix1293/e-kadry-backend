using EKadry.Domain.Workers;

namespace EKadry.API.Http.Worker.Request
{
    public class GetWorkerRequest
    {
        public WorkerId WorkerId { get; set; }
    }
}