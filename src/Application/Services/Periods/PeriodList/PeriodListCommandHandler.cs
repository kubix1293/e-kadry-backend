using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Pkzp.Period;

namespace EKadry.Application.Services.Periods.PeriodList
{
    public class JobPositionListCommandHandler : IQueryHandler<PeriodListQuery, IList<PeriodListDto>>
    {
        private readonly IPeriodRepository _periodRepository;
        private readonly IMapper _mapper;

        public JobPositionListCommandHandler(IPeriodRepository periodRepository, IMapper mapper)
        {
            _periodRepository = periodRepository;
            _mapper = mapper;
        }

        public async Task<IList<PeriodListDto>> Handle(PeriodListQuery query, CancellationToken cancellationToken)
        {
            var jobPositions = await _periodRepository.ToListAsync(query.SubMonths, query.NextMonths);
            
            return _mapper.Map<IList<Period>, IList<PeriodListDto>>(jobPositions);
        }
    }
}