using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EKadry.API.Http.Pkzp.Request;
using EKadry.Application.Services.Pkzp.PkzpPositionList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EKadry.API.Http.Pkzp
{
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
        
        /// <summary>
        /// Download PKZP positions from selected period 
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(FileResult), (int) HttpStatusCode.OK)] 
        public async Task<IActionResult> PkzpParam([FromQuery] DownloadListPkzpPositionRequest request)
        {
            var pkzp = await _mediator.Send(new PkzpFileQuery(
                request.Types,
                request.DateFrom,
                request.DateTo));
            
            return Ok(pkzp); 
        }
    }
}