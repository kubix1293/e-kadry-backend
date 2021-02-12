using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Pagination;
using EKadry.Domain.Pkzp.Position;
using EKadry.Domain.Workers;

namespace EKadry.Application.Services.Pkzp.PkzpAccounting
{
    public class PkzpAccountingCommandHandler : IQueryHandler<PkzpAccountingQuery, PagedList<PkzpPosition>>
    {
        private readonly IPkzpPositionRepository _pkzpPositionRepository;
        private readonly IMapper _mapper;

        public PkzpAccountingCommandHandler(IPkzpPositionRepository pkzpPositionRepository, IMapper mapper)
        {
            _pkzpPositionRepository = pkzpPositionRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<PkzpPosition>> Handle(PkzpAccountingQuery request, CancellationToken cancellationToken)
        {
            var accounting = await _pkzpPositionRepository.ToAccountingPaginated(
                request.Page,
                request.PerPage,
                request.OrderDirection,
                request.OrderBy,
                request.Search,
                request.PeriodId,
                cancellationToken).ToListAsync();

            return accounting;

            // return _mapper.Map<PagedList<PkzpPosition>, PagedList<PkzpAccountingDto>>(accounting);
        }
    }
}