using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Auth;
using EKadry.Domain.Operators;

namespace EKadry.Application.Services.Operators.OperatorAuthentication
{
    internal class OperatorAuthenticationQueryHandler : IQueryHandler<OperatorAuthenticationQuery, AuthorizedDto>
    {
        private readonly IAuthService _authService;
        private readonly IOperatorRepository _operatorRepository;
        private readonly IMapper _mapper;

        public OperatorAuthenticationQueryHandler(IAuthService authService, IOperatorRepository operatorRepository, IMapper mapper)
        {
            _authService = authService;
            _operatorRepository = operatorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorizedDto> Handle(OperatorAuthenticationQuery request, CancellationToken cancellationToken)
        {
            var @operator = await _operatorRepository.Authenticate(request.Login, request.Password);

            if (@operator == null)
            {
                throw new UnauthorizedAccessException();
            }

            var token = _authService.GenerateToken(new JwtContainerModel
            {
                Claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Login)
                }
            });

            var user = _mapper.Map<Operator, OperatorAuthorizedDto>(@operator);

            _authService.GetTokenClaims(token);

            return new AuthorizedDto()
            {
                Token = token,
                TokenType = "Bearer",
                Operator = user
            };
        }
    }
}