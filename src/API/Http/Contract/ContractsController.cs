using System;
using System.Net;
using System.Threading.Tasks;
using EKadry.API.Http.Contract.Request;
using EKadry.Application.Services.Contracts.ContractAdd;
using EKadry.Application.Services.Contracts.ContractDelete;
using EKadry.Application.Services.Contracts.ContractDetail;
using EKadry.Application.Services.Contracts.ContractList;
using EKadry.Application.Services.Contracts.ContractUpdate;
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
                request.JobPosition,
                request.ShowInactiveContracts == true,
                request.DateFrom,
                request.DateTo,
                request.HasPkzp
            ));

            return Ok(list);
        }

        /// <summary>
        /// Create new contract 
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Domain.Contracts.Contract), (int) HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] AddContractRequest request)
        {
            var contract = await _mediator.Send(new ContractAddCommand(
                request.EmployedAt,
                request.EmployedEndAt,
                request.BaseSalary,
                request.IdJobPosition,
                request.IdWorker,
                request.IdentifierZusNumber,
                request.IsSick,
                request.IsAnnuitant,
                request.IsPensioner,
                request.IsHealthy,
                request.IsLf,
                request.IsGebf,
                request.IsLeave,
                request.IsSickLeave,
                request.IsPkzp,
                request.WorkingTime,
                request.EntireInternship,
                request.ProfessionInternship,
                request.ServiceInternship,
                request.JubileeInternship
            ));

            return Created(contract.Id, contract);
        }
        
        /// <summary>
        /// Update contract 
        /// </summary>
        [HttpPut("{contractId}")]
        [ProducesResponseType(typeof(SuccessResponse), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromRoute] Guid contractId, [FromBody] AddContractRequest request)
        {
            var @operator = await _mediator.Send(new ContractUpdateCommand(
                contractId,
                request.EmployedAt,
                request.EmployedEndAt,
                request.BaseSalary,
                request.IdJobPosition,
                request.IdentifierZusNumber,
                request.IsSick,
                request.IsAnnuitant,
                request.IsPensioner,
                request.IsHealthy,
                request.IsLf,
                request.IsGebf,
                request.IsLeave,
                request.IsSickLeave,
                request.IsPkzp,
                request.WorkingTime,
                request.EntireInternship,
                request.ProfessionInternship,
                request.ServiceInternship,
                request.JubileeInternship
            ));

            return SuccessResponse("Umowa została zaktualizowana");
        }

        /// <summary>
        /// Get contract details
        /// </summary>
        [HttpGet("{contractId}")]
        [ProducesResponseType(typeof(ContractDetailDto), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] Guid contractId)
        {
            var contract = await _mediator.Send(new ContractDetailQuery(contractId));

            return Ok(contract);
        }

        /// <summary>
        /// Delete contract 
        /// </summary>
        [HttpDelete("{contractId}")]
        [ProducesResponseType(typeof(SuccessResponse), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] Guid contractId)
        {
            await _mediator.Send(new ContractDeleteCommand(contractId));
            return SuccessResponse("Pracownik został umowa");
        }
    }
}