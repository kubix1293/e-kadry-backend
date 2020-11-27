using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Operators;

namespace EKadry.Application.Services.Operators.OperatorAuthentication
{
    internal class OperatorAuthenticationQueryHandler: IQueryHandler<OperatorAuthenticationQuery, OperatorAuthorizedDto>
    {
        private readonly IOperatorRepository _operatorRepository;
        private readonly IMapper _mapper;

        public OperatorAuthenticationQueryHandler(IOperatorRepository operatorRepository, IMapper mapper)
        {
            _operatorRepository = operatorRepository;
            _mapper = mapper;
        }
        
        public async Task<OperatorAuthorizedDto> Handle(OperatorAuthenticationQuery request, CancellationToken cancellationToken)
        {
            var @operator = await _operatorRepository.Authenticate(request.Login, request.Password);

            if (@operator == null)
            {
                throw new UnauthorizedAccessException();
            }

            return _mapper.Map<Operator, OperatorAuthorizedDto>(@operator);
        }
    }
}