using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EKadry.API.Http.Pkzp.Request;
using EKadry.Application.Services.Pkzp.PkzpPositionList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EKadry.API.Http.Pkzp
{
    [Authorize]
    [ApiController]
    [Route("api/pkzp-positions")]
    public class PkzpPositionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PkzpPositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all PKZP positions for worker
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<PkzpPositionListDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery] ListPkzpPositionRequest request)
        {
            var pkzpPositions = await _mediator.Send(new PkzpPositionListQuery(
                request.Page,
                request.PerPage,
                request.OrderDirection,
                request.OrderBy,
                request.Search,
                request.WorkerId
            ));

            return Ok(pkzpPositions);
        }
    }
}