using System;
using System.Threading;
using System.Threading.Tasks;
using EKadry.Application.Configuration.Commands;
using EKadry.Domain.Workers;

namespace EKadry.Application.Services.Workers.WorkerDelete
{
    public class WorkerDeleteCommandHandler : ICommandHandler<WorkerDeleteCommand, int>
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerDeleteCommandHandler(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public async Task<int> Handle(WorkerDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _workerRepository.DeleteAsync(new Guid(request.Id.ToByteArray()));
        }
    }
}