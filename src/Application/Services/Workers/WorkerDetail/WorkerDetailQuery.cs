using System;
using EKadry.Application.Configuration.Queries;

namespace EKadry.Application.Services.Workers.WorkerDetail
{
    public class WorkerDetailQuery : IQuery<WorkerDetailDto>
    {
        public readonly Guid Guid;

        public WorkerDetailQuery(Guid workerId)
        {
            Guid = workerId;
        }
    }
}