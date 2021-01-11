using System;
using EKadry.Application.Configuration.Commands;

namespace EKadry.Application.Services.Workers.WorkerDelete
{
    public class WorkerDeleteCommand : CommandBase<int>
    {
        public WorkerDeleteCommand(Guid id) : base(id)
        {
        }
    }
}