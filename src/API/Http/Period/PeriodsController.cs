using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EKadry.API.Http.Period.Request;
using EKadry.Application.Services.Periods.PeriodList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EKadry.API.Http.Period
{
    [ApiController]
    [Route("api/period")]
    public class PeriodController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PeriodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// List of job positions
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IList<PeriodListDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> List([FromQuery] PeriodRequest request)
        {
            var list = await _mediator.Send(new PeriodListQuery(
                request.SubMonths,
                request.NextMonths
            ));
            
            return Ok(list);
        }
    }
}