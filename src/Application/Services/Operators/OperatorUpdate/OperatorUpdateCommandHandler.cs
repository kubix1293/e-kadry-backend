using System.Threading;
using System.Threading.Tasks;
using EKadry.Application.Configuration.Commands;
using EKadry.Domain.Operators;
using MediatR;

namespace EKadry.Application.Services.Operators.OperatorUpdate
{
    public class OperatorUpdateCommandHandler : ICommandHandler<OperatorUpdateCommand, Unit>
    {
        private readonly IOperatorRepository _operatorRepository;

        public OperatorUpdateCommandHandler(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public async Task<Unit> Handle(OperatorUpdateCommand request, CancellationToken cancellationToken)
        {
            var @operator = await _operatorRepository.GetAsync(request.Id);
            @operator.Update(request.Login, request.FirstName, request.LastName, request.Active, request.Password);
            await _operatorRepository.UpdateAsync(@operator);
            return Unit.Value;
        }
    }
}