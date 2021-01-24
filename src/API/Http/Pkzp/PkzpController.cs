using System.Net;
using System.Threading.Tasks;
using EKadry.API.Http.Pkzp.Request;
using EKadry.Application.Services.Pkzp;
using EKadry.Application.Services.Pkzp.PkzpCreate;
using EKadry.Application.Services.Pkzp.PkzpParameters;
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
        [HttpPost]
        [ProducesResponseType(typeof(PkzpDto), (int) HttpStatusCode.Created)]
        public async Task<IActionResult> List([FromBody] CreatePkzpRequest request)
        {
            var pkzp = await _mediator.Send(new PkzpCreateCommand(
                request.PkzpPositionType,
                request.PeriodId,
                request.WorkerId,
                request.Amount,
                request.InstallmentsCount,
                request.InstallmentAmount
            ));
            
            return Created(pkzp.Id, pkzp);
        }

        /// <summary>
        /// Get PKZP parameters 
        /// </summary>
        [HttpGet("parameters")]
        [ProducesResponseType(typeof(PkzpDto), (int) HttpStatusCode.OK)] 
        public async Task<IActionResult> PkzpParam()
        {
            var pkzp = await _mediator.Send(new PkzpParametersQuery());
            
            return Ok(pkzp); 
        }
    }
}