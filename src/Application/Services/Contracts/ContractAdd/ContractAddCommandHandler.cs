using System.Threading;
using System.Threading.Tasks;
using EKadry.Application.Configuration.Commands;
using EKadry.Domain.Contracts;

namespace EKadry.Application.Services.Contracts.ContractAdd
{
    public class ContractAddCommandHandler : ICommandHandler<ContractAddCommand, ContractDto>
    {
        private readonly IContractRepository _contractRepository;

        public ContractAddCommandHandler(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<ContractDto> Handle(ContractAddCommand request, CancellationToken cancellationToken)
        {
            var contract = Contract.CreateContract(
                request.EmployedAt,
                request.EmployedEndAt,
                request.BaseSalary,
                request.IdJobPosition,
                request.IdWorker,
                request.IdentifierZusNumber,
                request.IsSick,
                request.IsAnnuitant,
                request.IsPensioner,
                request.IsHealthy,
                request.IsLf,
                request.IsGebf,
                request.IsLeave,
                request.IsSickLeave,
                request.WorkingTime,
                request.EntireInternship,
                request.ProfessionInternship,
                request.ServiceInternship,
                request.JubileeInternship
                );
            await _contractRepository.AddAsync(contract);
            return new ContractDto {Id = contract.Id};
        }
    }
}