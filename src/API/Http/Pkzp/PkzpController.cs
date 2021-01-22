using System.Net;
using System.Threading.Tasks;
using EKadry.API.Http.Pkzp.Request;
using EKadry.Application.Services.Pkzp;
using EKadry.Application.Services.Pkzp.PkzpCreate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EKadry.API.Http.Pkzp
{
    [ApiController]
    [Route("api/pkzp")]
    public class PkzpController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PkzpController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create PKZP for an worker
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(PkzpDto), (int) HttpStatusCode.Created)]
        public async Task<IActionResult> List([FromQuery] CreatePkzpRequest request)
        {
            var pkzp = await _mediator.Send(new PkzpCreateCommand(
                request.PkzpType,
                request.DateFrom,
                request.DateTo,
                request.WorkerId,
                request.Amount,
                request.InstallmentsCount,
                request.InstallmentAmount
            ));
            
            return Created(pkzp.Id, pkzp);
        }
    }
}