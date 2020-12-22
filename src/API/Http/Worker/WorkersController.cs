using System;
using System.Net;
using System.Threading.Tasks;
using EKadry.API.Http.Worker.Request;
using EKadry.Application.Services.Workers.WorkerAdd;
using EKadry.Application.Services.Workers.WorkerDetail;
using EKadry.Application.Services.Workers.WorkerList;
using EKadry.Domain.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Create new worker 
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Domain.Operators.Operator), (int) HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] AddWorkerRequest request)
        {
            var @operator = await _mediator.Send(new WorkerAddCommand(
                request.FirstName,
                request.LastName,
                request.Birthday,
                request.CityOfBirthday,
                request.Pesel,
                request.DoumnetType,
                request.DocumentNumber,
                request.Gender,
                request.IdCity,
                request.Street,
                request.PropertyNumber,
                request.ApartmentNumber,
                request.ActNumber,
                request.MotherName,
                request.FatherName,
                request.Phone
            ));

            return Created(@operator.Id, @operator);
        }

        /// <summary>
        /// Get worker details
        /// </summary>
        [HttpGet("{workerId}")]
        [ProducesResponseType(typeof(WorkerDetailDto), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] Guid workerId)
        {
            var worker = await _mediator.Send(new WorkerDetailQuery(workerId));

            return Ok(worker);
        }

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