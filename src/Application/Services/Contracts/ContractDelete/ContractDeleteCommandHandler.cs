using System;
using System.Threading;
using System.Threading.Tasks;
using EKadry.Application.Configuration.Commands;
using EKadry.Domain.Contracts;

namespace EKadry.Application.Services.Contracts.ContractDelete
{
    public class ContractDeleteCommandHandler : ICommandHandler<ContractDeleteCommand, int>
    {
        private readonly IContractRepository _contractRepository;

        public ContractDeleteCommandHandler(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<int> Handle(ContractDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _contractRepository.DeleteAsync(new Guid(request.Id.ToByteArray()));
        }
    }
}