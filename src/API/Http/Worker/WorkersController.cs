using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using EKadry.API.Http.Operator.Request;
using EKadry.Application.Services.Operators.OperatorAdd;
using EKadry.Application.Services.Operators.OperatorDelete;
using EKadry.Application.Services.Operators.OperatorDetail;
using EKadry.Application.Services.Operators.OperatorList;
using EKadry.Application.Services.Workers.WorkerList;
using EKadry.Domain.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EKadry.API.Http.Worker
{
    [ApiController]
    [Route("api/workers")]
    public class WorkersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// List of workers
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(PagedList<WorkerListDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> List([FromQuery] ListRequest request)
        {
            var list = await _mediator.Send(new WorkerListQuery(
                request.Page,
                request.PerPage,
                request.OrderDirection,
                request.OrderBy,
                request.Search
            ));

            return Ok(list);
        }
        
        // /// <summary>
        // /// Create new worker 
        // /// </summary>
        // [HttpPost]
        // [ProducesResponseType(typeof(Domain.Operators.Operator), (int) HttpStatusCode.Created)]
        // public async Task<IActionResult> Create([FromBody] AddOperatorRequest request)
        // {
        //     var @operator = await _mediator.Send(new OperatorAddCommand(
        //         request.Login,
        //         request.Password,
        //         request.FirstName,
        //         request.LastName
        //     ));
        //     Thread.Sleep(500);
        //
        //     return Created(@operator.Id, @operator);
        // }
        //
        // /// <summary>
        // /// Get worker details
        // /// </summary>
        // [HttpGet("{workerId}")]
        // [ProducesResponseType(typeof(OperatorDetailDto), (int) HttpStatusCode.OK)]
        // public async Task<IActionResult> Get([FromRoute] Guid workerId)
        // {
        //     var @operator = await _mediator.Send(new OperatorDetailQuery(workerId));
        //
        //     return Ok(@operator);
        // }
        //
        // /// <summary>
        // /// Delete worker 
        // /// </summary>
        // [HttpDelete("{workerId}")]
        // [ProducesResponseType(typeof(SuccessResponse), (int) HttpStatusCode.OK)]
        // [ProducesResponseType(typeof(FailedResponse), (int) HttpStatusCode.BadRequest)]
        // public async Task<IActionResult> Delete([FromRoute] Guid workerId)
        // {
        //     if (await _mediator.Send(new OperatorDeleteCommand(workerId)) == 0)
        //     {
        //         return FailedResponse("Nie udało się usunięcie pracownika");
        //     }
        //     
        //     return SuccessResponse("Pracownik został usunięy");
        // }
    }
}