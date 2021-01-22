using System.Threading;
using System.Threading.Tasks;
using EKadry.Application.Configuration.Commands;
using PkzpDomain = EKadry.Domain.Pkzp;

namespace EKadry.Application.Services.Pkzp.PkzpCreate
{
    public class PkzpCreateCommandHandler : ICommandHandler<PkzpCreateCommand, PkzpDto>
    {
        private readonly PkzpDomain.IPkzpRepository _pkzpRepository;

        public PkzpCreateCommandHandler(PkzpDomain.IPkzpRepository pkzpRepository)
        {
            _pkzpRepository = pkzpRepository;
        }

        public async Task<PkzpDto> Handle(PkzpCreateCommand request, CancellationToken cancellationToken)
        {
            var pkzp = PkzpDomain.Pkzp.Create(
                request.PkzpType,
                );
            
            await _pkzpRepository.CreateAsync(pkzp);
            return new PkzpDto {Id = pkzp.Id};
        }
    }
}