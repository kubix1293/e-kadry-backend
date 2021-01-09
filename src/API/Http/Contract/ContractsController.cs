using System;
using System.Net;
using System.Threading.Tasks;
using EKadry.API.Http.Contract.Request;
using EKadry.API.Http.Worker.Request;
using EKadry.Application.Services.Contracts.ContractDetail;
using EKadry.Application.Services.Contracts.ContractList;
using EKadry.Application.Services.Workers.WorkerAdd;
using EKadry.Application.Services.Workers.WorkerDetail;
using EKadry.Application.Services.Workers.WorkerList;
using EKadry.Domain.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EKadry.API.Http.Contract
{
    [ApiController]
    [Route("api/contracts")]
    public class ContractsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContractsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// List of employment contracts
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(PagedList<ContractListDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> List([FromQuery] ContractListRequest request)
        {
            var list = await _mediator.Send(new ContractListQuery(
                request.Page,
                request.PerPage,
                request.OrderDirection,
                request.OrderBy,
                request.Search,
                request.ShowInactiveContracts == true,
                request.DateFrom,
                request.DateTo
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
        /// Get worker details
        /// </summary>
        [HttpGet("{contractId}")]
        [ProducesResponseType(typeof(ContractDetailDto), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] Guid contractId)
        {
            var contract = await _mediator.Send(new ContractDetailQuery(contractId));

            return Ok(contract);
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