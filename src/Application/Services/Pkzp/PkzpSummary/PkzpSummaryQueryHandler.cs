using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using PkzpDomain = EKadry.Domain.Pkzp;

namespace EKadry.Application.Services.Pkzp.PkzpSummary
{
    public class PkzpCreateQueryHandler : IQueryHandler<PkzpSummaryQuery, PkzpSummaryDto>
    {
        private readonly PkzpDomain.IPkzpRepository _pkzpRepository;
        private readonly IMapper _mapper;

        public PkzpCreateQueryHandler(PkzpDomain.IPkzpRepository pkzpRepository, IMapper mapper)
        {
            _pkzpRepository = pkzpRepository;
            _mapper = mapper;
        }

        public async Task<PkzpSummaryDto> Handle(PkzpSummaryQuery request, CancellationToken cancellationToken)
        {
            var pkzp = await _pkzpRepository.GetByWorkerAsync(request.WorkerId);
            return _mapper.Map<PkzpDomain.Pkzp, PkzpSummaryDto>(pkzp);
        }
    }
}