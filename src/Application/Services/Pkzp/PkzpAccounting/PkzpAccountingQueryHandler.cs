using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Pagination;
using EKadry.Domain.Workers;

namespace EKadry.Application.Services.Pkzp.PkzpAccounting
{
    public class PkzpAccountingCommandHandler : IQueryHandler<PkzpAccountingQuery, PagedList<PkzpAccountingDto>>
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IMapper _mapper;

        public PkzpAccountingCommandHandler(IWorkerRepository workerRepository, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<PkzpAccountingDto>> Handle(PkzpAccountingQuery request, CancellationToken cancellationToken)
        {
            var accounting = await _workerRepository.ToAccountingPaginated(
                request.Page,
                request.PerPage,
                request.OrderDirection,
                request.OrderBy,
                request.Search,
                request.PeriodId,
                cancellationToken).ToListAsync();

            return _mapper.Map<PagedList<Worker>, PagedList<PkzpAccountingDto>>(accounting);
        }
    }
}