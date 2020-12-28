using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Workers;

namespace EKadry.Application.Services.Workers.WorkerDetail
{
    public class WorkerDetailQueryHandler : IQueryHandler<WorkerDetailQuery, WorkerDetailDto>
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IMapper _mapper;

        public WorkerDetailQueryHandler(IWorkerRepository workerRepository, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
        }

        public async Task<WorkerDetailDto> Handle(WorkerDetailQuery request, CancellationToken cancellationToken)
        {
            var worker = await _workerRepository.GetAsync(new Guid(request.Guid.ToByteArray()));

            return _mapper.Map<Worker, WorkerDetailDto>(worker);
        }
    }
}