using System.Threading;
using System.Threading.Tasks;
using EKadry.Application.Configuration.Commands;
using EKadry.Domain.Operators;

namespace EKadry.Application.Services.Operators.OperatorAdd
{
    public class OperatorAddCommandHandler : ICommandHandler<OperatorAddCommand, OperatorDto>
    {
        private readonly IOperatorRepository _operatorRepository;

        public OperatorAddCommandHandler(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public async Task<OperatorDto> Handle(OperatorAddCommand request, CancellationToken cancellationToken)
        {
            var @operator = Operator.CreateOperator(request.Login, request.Password, request.FirstName, request.LastName);
            await _operatorRepository.AddAsync(@operator);
            return new OperatorDto {Id = @operator.Id.Value};
        }
    }
}