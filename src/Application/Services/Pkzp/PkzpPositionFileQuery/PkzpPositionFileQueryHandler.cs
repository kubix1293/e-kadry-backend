using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Pagination;
using EKadry.Domain.Pkzp.Position;

namespace EKadry.Application.Services.Pkzp.PkzpPositionFileqQuery
{
    public class PkzpPositionListQueryHandler : IQueryHandler<PkzpPositionListQuery, PagedList<PkzpPositionListDto>>
    {
        private readonly IPkzpPositionRepository _pkzpPositionRepository;
        private readonly IMapper _mapper;

        public PkzpPositionListQueryHandler(IPkzpPositionRepository pkzpPositionRepository, IMapper mapper)
        {
            _pkzpPositionRepository = pkzpPositionRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<PkzpPositionListDto>> Handle(PkzpPositionListQuery request, CancellationToken cancellationToken)
        {
            var pkzpPositions = await _pkzpPositionRepository.ToListPaginated(
                request.Page,
                request.PerPage,
                request.OrderDirection,
                request.OrderBy,
                request.Search,
                request.WorkerId,
                cancellationToken).ToListAsync();

            return _mapper.Map<PagedList<PkzpPosition>, PagedList<PkzpPositionListDto>>(pkzpPositions);
        }
    }
}