using System.Threading;
using System.Threading.Tasks;
using EKadry.Application.Configuration.Commands;
using EKadry.Domain.Pkzp.Period;
using PkzpDomain = EKadry.Domain.Pkzp;

namespace EKadry.Application.Services.Pkzp.PkzpCreate
{
    public class PkzpCreateCommandHandler : ICommandHandler<PkzpCreateCommand, PkzpDto>
    {
        private readonly PkzpDomain.IPkzpRepository _pkzpRepository;
        private readonly IPeriodRepository _periodRepository;

        public PkzpCreateCommandHandler(PkzpDomain.IPkzpRepository pkzpRepository, IPeriodRepository periodRepository)
        {
            _pkzpRepository = pkzpRepository;
            _periodRepository = periodRepository;
        }

        public async Task<PkzpDto> Handle(PkzpCreateCommand request, CancellationToken cancellationToken)
        {
            var pkzp = PkzpDomain.Position.PkzpPosition.Create();

            await _pkzpRepository.CreateAsync(
                pkzp.Id,
                request.PkzpPositionType,
                request.PeriodId,
                request.WorkerId,
                request.Amount,
                request.InstallmentsCount,
                request.InstallmentAmount);
            
            return new PkzpDto {Id = pkzp.Id};
        }
    }
}