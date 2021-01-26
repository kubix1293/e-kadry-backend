using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Pkzp.Position;

namespace EKadry.Application.Services.Pkzp.PkzpPositionList
{
    public class PkzpPositionListQueryHandler : IQueryHandler<PkzpPositionListQuery, List<PkzpPositionListDto>>
    {
        private readonly IPkzpPositionRepository _pkzpPositionRepository;
        private readonly IMapper _mapper;

        public PkzpPositionListQueryHandler(IPkzpPositionRepository pkzpPositionRepository, IMapper mapper)
        {
            _pkzpPositionRepository = pkzpPositionRepository;
            _mapper = mapper;
        }

        public async Task<List<PkzpPositionListDto>> Handle(PkzpPositionListQuery request, CancellationToken cancellationToken)
        {
            var pkzpPositions = await _pkzpPositionRepository.ToListAsync(request.WorkerId);
            return _mapper.Map<List<PkzpPosition>, List<PkzpPositionListDto>>(pkzpPositions);
        }
    }
}