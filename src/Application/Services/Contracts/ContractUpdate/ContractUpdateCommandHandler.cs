using System.Threading;
using System.Threading.Tasks;
using EKadry.Application.Configuration.Commands;
using EKadry.Domain.Contracts;
using MediatR;

namespace EKadry.Application.Services.Contracts.ContractUpdate
{
    public class ContractAddCommandHandler : ICommandHandler<ContractUpdateCommand, Unit>
    {
        private readonly IContractRepository _contractRepository;

        public ContractAddCommandHandler(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<Unit> Handle(ContractUpdateCommand request, CancellationToken cancellationToken)
        {
            var contract = await _contractRepository.GetAsync(request.Id);
            contract.Update(
                request.EmployedAt,
                request.EmployedEndAt,
                request.BaseSalary,
                request.IdJobPosition,
                request.IdentifierZusNumber,
                request.IsSick,
                request.IsAnnuitant,
                request.IsPensioner,
                request.IsHealthy,
                request.IsLf,
                request.IsGebf,
                request.IsLeave,
                request.IsSickLeave,
                request.IsPkzp,
                request.WorkingTime,
                request.EntireInternship,
                request.ProfessionInternship,
                request.ServiceInternship,
                request.JubileeInternship
            );
            await _contractRepository.UpdateAsync(contract);
            return Unit.Value;
        }
    }
}