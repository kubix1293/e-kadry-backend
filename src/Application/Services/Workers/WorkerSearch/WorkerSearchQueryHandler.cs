using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Workers;

namespace EKadry.Application.Services.Workers.WorkerSearch
{
    public class WorkerSearchQueryHandler : IQueryHandler<WorkerSearchQuery, List<WorkerSearchDto>>
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IMapper _mapper;

        public WorkerSearchQueryHandler(IWorkerRepository workerRepository, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
        }

        public async Task<List<WorkerSearchDto>> Handle(WorkerSearchQuery request, CancellationToken cancellationToken)
        {
            var worker = await _workerRepository.Search(request.SearchKey, request.Limit);

            return _mapper.Map<List<Worker>, List<WorkerSearchDto>>(worker);
        }
    }
}