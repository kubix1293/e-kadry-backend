using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using EKadry.API.Http.Operator.Request;
using EKadry.Application.Services.Operators.OperatorAdd;
using EKadry.Application.Services.Operators.OperatorDelete;
using EKadry.Application.Services.Operators.OperatorDetail;
using EKadry.Application.Services.Operators.OperatorList;
using EKadry.Domain.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EKadry.API.Http.Operator
{
    [ApiController]
    [Route("api/operators")]
    public class OperatorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public OperatorsController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        /// <summary>
        /// List of operators
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(PagedList<OperatorListDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> List([FromQuery] ListRequest request)
        {
            var list = await _mediator.Send(new OperatorListQuery(
                request.Page,
                request.PerPage,
                request.OrderDirection,
                request.OrderBy,
                request.Search
            ));
            
            return Ok(list);
        }
        
        /// <summary>
        /// Create new operator 
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Domain.Operators.Operator), (int) HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] AddOperatorRequest request)
        {
            var @operator = await _mediator.Send(new OperatorAddCommand(
                request.Login,
                request.Password,
                request.FirstName,
                request.LastName
            ));
            Thread.Sleep(500);
        
            return Created(@operator.Id, @operator);
        }
        
        /// <summary>
        /// Get operator details
        /// </summary>
        [HttpGet("{operatorId}")]
        [ProducesResponseType(typeof(OperatorDetailDto), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] Guid operatorId)
        {
            var @operator = await _mediator.Send(new OperatorDetailQuery(operatorId));
        
            return Ok(@operator);
        }
        
        /// <summary>
        /// Delete operator 
        /// </summary>
        [HttpDelete("{operatorId}")]
        [ProducesResponseType(typeof(SuccessResponse), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResponse), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] Guid operatorId)
        {
            if (await _mediator.Send(new OperatorDeleteCommand(operatorId)) == 0)
            {
                return FailedResponse("Nie udało się usunięcie operatora.");
            }
            
            return SuccessResponse("Operator został usunięy");
        }
    }
}