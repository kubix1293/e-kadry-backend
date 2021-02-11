using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EKadry.API.Http.JobPosition.Request;
using EKadry.Application.Services.JobPositions.JobPositionList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EKadry.API.Http.JobPosition
{
    [Authorize]
    [ApiController]
    [Route("api/job-positions")]
    public class JobPositionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobPositionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// List of job positions
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IList<JobPositionListDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> List([FromQuery] JobPositionSearchRequest request)
        {
            var list = await _mediator.Send(new JobPositionListQuery(
                request.Search,
                request.PerPage
            ));
            
            return Ok(list);
        }
    }
}