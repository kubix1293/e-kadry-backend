using System;
using System.Net;
using System.Threading.Tasks;
using EKadry.API.Http.Operator.Request;
using EKadry.Application.Services.Operators.OperatorAuthentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EKadry.API.Http.Operator
{
    [ApiController]
    [Route("api/auth")]
    public class OperatorAuthorizationController : Controller
    {
        private readonly IMediator _mediator;

        public OperatorAuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Login registered operator 
        /// </summary>
        [HttpPost()]
        [ProducesResponseType(typeof(OperatorAuthorizedDto), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var @operator = await _mediator.Send(new OperatorAuthenticationQuery(request.Login, request.Password));
                return Ok(@operator);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized();
            }
        }
    }
}