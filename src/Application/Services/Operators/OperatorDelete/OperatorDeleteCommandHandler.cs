using System.Threading;
using System.Threading.Tasks;
using EKadry.Application.Configuration.Commands;
using EKadry.Domain.Operators;
using MediatR;

namespace EKadry.Application.Services.Operators.OperatorDelete
{
    public class OperatorDeleteCommandHandler : ICommandHandler<OperatorDeleteCommand, int>
    {
        private readonly IOperatorRepository _operatorRepository;

        public OperatorDeleteCommandHandler(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public async Task<int> Handle(OperatorDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _operatorRepository.DeleteAsync(new OperatorId(request.Id));
        }
    }
}