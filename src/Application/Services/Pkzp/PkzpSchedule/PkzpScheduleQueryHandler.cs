using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Pagination;
using EKadry.Domain.Pkzp.Schedule;

namespace EKadry.Application.Services.Pkzp.PkzpSchedule
{
    public class PkzpAccountingCommandHandler : IQueryHandler<PkzpScheduleQuery, PagedList<PkzpScheduleDto>>
    {
        private readonly IPkzpScheduleRepository _pkzpScheduleRepository;
        private readonly IMapper _mapper;

        public PkzpAccountingCommandHandler(IPkzpScheduleRepository pkzpScheduleRepository, IMapper mapper)
        {
            _pkzpScheduleRepository = pkzpScheduleRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<PkzpScheduleDto>> Handle(PkzpScheduleQuery request, CancellationToken cancellationToken)
        {
            var schedule = await _pkzpScheduleRepository.List(
                request.Page,
                request.PerPage,
                request.OrderDirection,
                request.OrderBy,
                request.Search,
                request.PkzpPositionId,
                cancellationToken).ToListAsync();

            return _mapper.Map<PagedList<Domain.Pkzp.Schedule.PkzpSchedule>, PagedList<PkzpScheduleDto>>(schedule);
        }
    }
}