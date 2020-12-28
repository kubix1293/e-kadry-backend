using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Pagination;
using EKadry.Domain.Workers;

namespace EKadry.Application.Services.Workers.WorkerList
{
    public class WorkerListCommandHandler : IQueryHandler<WorkerListQuery, PagedList<WorkerListDto>>
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IMapper _mapper;

        public WorkerListCommandHandler(IWorkerRepository workerRepository, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<WorkerListDto>> Handle(WorkerListQuery query, CancellationToken cancellationToken)
        {
            var operators = await _workerRepository.ToListPaginated(
                query.Page,
                query.PerPage,
                query.OrderDirection,
                query.OrderBy,
                query.Search,
                cancellationToken).ToListAsync();
            
            return _mapper.Map<PagedList<Worker>, PagedList<WorkerListDto>>(operators);
        }
    }
}