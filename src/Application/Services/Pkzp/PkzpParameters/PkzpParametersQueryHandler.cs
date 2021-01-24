using System.Threading;
using System.Threading.Tasks;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Pkzp.Parameters;
using PkzpDomain = EKadry.Domain.Pkzp;

namespace EKadry.Application.Services.Pkzp.PkzpParameters
{
    public class PkzpParametersCommandHandler : IQueryHandler<PkzpParametersQuery, Domain.Pkzp.Parameters.PkzpParameters>
    {
        private readonly IPkzpParametersRepository _pkzpParametersRepository;

        public PkzpParametersCommandHandler(IPkzpParametersRepository pkzpParametersRepository)
        {
            _pkzpParametersRepository = pkzpParametersRepository;
        }

        public async Task<Domain.Pkzp.Parameters.PkzpParameters> Handle(PkzpParametersQuery request, CancellationToken cancellationToken)
        {
            return await _pkzpParametersRepository.Get();
        }
    }
}