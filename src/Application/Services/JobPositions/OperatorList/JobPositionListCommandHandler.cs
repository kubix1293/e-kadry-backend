using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Contracts.JobPosition;

namespace EKadry.Application.Services.JobPositions.OperatorList
{
    public class JobPositionListCommandHandler : IQueryHandler<JobPositionListQuery, IList<JobPositionListDto>>
    {
        private readonly IJobPositionRepository _jobPositionRepository;
        private readonly IMapper _mapper;

        public JobPositionListCommandHandler(IJobPositionRepository jobPositionRepository, IMapper mapper)
        {
            _jobPositionRepository = jobPositionRepository;
            _mapper = mapper;
        }

        public async Task<IList<JobPositionListDto>> Handle(JobPositionListQuery query, CancellationToken cancellationToken)
        {
            var jobPositions = await _jobPositionRepository.ToListAsync(query.Search, query.PerPage);
            
            return _mapper.Map<IList<JobPosition>, IList<JobPositionListDto>>(jobPositions);
        }
    }
}