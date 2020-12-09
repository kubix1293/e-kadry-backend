using System;
using EKadry.Application.Configuration.Queries;

namespace EKadry.Application.Services.Workers.WorkerDetail
{
    public class WorkerDetailQuery : IQuery<WorkerDetailDto>
    {
        public readonly Guid WorkerId;

        public WorkerDetailQuery(Guid workerId)
        {
            WorkerId = workerId;
        }
    }
}