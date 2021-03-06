using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EKadry.API.Http.Worker.Request;
using EKadry.Application.Services.Workers.WorkerAdd;
using EKadry.Application.Services.Workers.WorkerDelete;
using EKadry.Application.Services.Workers.WorkerDetail;
using EKadry.Application.Services.Workers.WorkerList;
using EKadry.Application.Services.Workers.WorkerSearch;
using EKadry.Application.Services.Workers.WorkerUpdate;
using EKadry.Domain.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EKadry.API.Http.Worker
{
    [Authorize]
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
        public async Task<IActionResult> List([FromQuery] WorkerListRequest request)
        {
            var list = await _mediator.Send(new WorkerListQuery(
                request.Page,
                request.PerPage,
                request.OrderDirection,
                request.OrderBy,
                request.Search,
                request.ShowInactiveContracts ?? false,
                request.HasPkzp,
                request.JobPosition
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
                request.DocumentType,
                request.DocumentNumber,
                request.Gender,
                request.Street,
                request.PropertyNumber,
                request.ApartmentNumber,
                request.ZipCode,
                request.City,
                request.Country,
                request.ActNumber,
                request.MotherName,
                request.FatherName,
                request.Phone
            ));

            return Created(@operator.Id, @operator);
        }
        
        /// <summary>
        /// Update operator 
        /// </summary>
        [HttpPut("{workerId}")]
        [ProducesResponseType(typeof(SuccessResponse), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromRoute] Guid workerId, [FromBody] UpdateWorkerRequest request)
        {
            await _mediator.Send(new WorkerUpdateCommand(
                workerId,
                request.FirstName,
                request.LastName,
                request.Birthday,
                request.CityOfBirthday,
                request.Pesel,
                request.DocumentType,
                request.DocumentNumber,
                request.Gender,
                request.Street,
                request.PropertyNumber,
                request.ApartmentNumber,
                request.ZipCode,
                request.City,
                request.Country,
                request.ActNumber,
                request.MotherName,
                request.FatherName,
                request.Phone
            ));
        
            return SuccessResponse("Pracownik został zaktualizowany");
        }

        /// <summary>
        /// Get worker details
        /// </summary>
        [HttpGet("{workerId}")]
        // [ProducesResponseType(typeof(WorkerDetailDto), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] Guid workerId)
        {
            var worker = await _mediator.Send(new WorkerDetailQuery(workerId));

            return Ok(worker);
        }
        
        /// <summary>
        /// Search workers
        /// </summary>
        [HttpGet("search")]
        [ProducesResponseType(typeof(List<WorkerSearchDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery] SearchQueryRequest searchParams)
        {
            var worker = await _mediator.Send(new WorkerSearchQuery(searchParams.SearchKey, searchParams.Limit));

            return Ok(worker);
        }

        /// <summary>
        /// Delete worker 
        /// </summary>
        [HttpDelete("{workerId}")]
        [ProducesResponseType(typeof(SuccessResponse), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] Guid workerId)
        {
            await _mediator.Send(new WorkerDeleteCommand(workerId));
            return SuccessResponse("Pracownik został usunięty");
        }
    }
}