using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EKadry.API.Http.Pkzp.Request;
using EKadry.Application.Services.Pkzp;
using EKadry.Application.Services.Pkzp.PkzpAccounting;
using EKadry.Application.Services.Pkzp.PkzpCreate;
using EKadry.Application.Services.Pkzp.PkzpParameters;
using EKadry.Application.Services.Pkzp.PkzpSchedule;
using EKadry.Application.Services.Pkzp.PkzpSummary;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EKadry.API.Http.Pkzp
{
    [Authorize]
    [ApiController]
    [Route("api/pkzp")]
    public class PkzpController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PkzpController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Get PKZP summary for worker
        /// </summary>
        [HttpGet("{workerId}")]
        [ProducesResponseType(typeof(List<PkzpSummaryDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] Guid workerId)
        {
            var pkzpSummary = await _mediator.Send(new PkzpSummaryQuery(workerId));
            
            return Ok(pkzpSummary);
        }

        /// <summary>
        /// Create PKZP for an worker
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(PkzpDto), (int) HttpStatusCode.Created)]
        public async Task<IActionResult> List([FromBody] CreatePkzpRequest request)
        {
            var pkzp = await _mediator.Send(new PkzpCreateCommand(
                request.PkzpPositionType,
                request.PeriodId,
                request.WorkerId,
                request.Amount,
                request.InstallmentsCount,
                request.InstallmentAmount
            ));
            
            return Created(pkzp.Id, pkzp);
        }

        /// <summary>
        /// Get PKZP parameters 
        /// </summary>
        [HttpGet("parameters")]
        [ProducesResponseType(typeof(PkzpDto), (int) HttpStatusCode.OK)] 
        public async Task<IActionResult> PkzpParam()
        {
            var pkzp = await _mediator.Send(new PkzpParametersQuery());
            
            return Ok(pkzp); 
        }
        
        /// <summary>
        /// Get PKZP accounting information
        /// </summary>
        [HttpGet("accounting")]
        [ProducesResponseType(typeof(PkzpAccountingDto), (int) HttpStatusCode.OK)] 
        public async Task<IActionResult> PkzpAccounting([FromQuery] PkzpAccountingRequest request)
        {
            var accounting = await _mediator.Send(new PkzpAccountingQuery(
                request.Page,
                request.PerPage,
                request.OrderDirection,
                request.OrderBy,
                request.Search,
                request.PeriodId));
            
            return Ok(accounting); 
        }
        
        /// <summary>
        /// Get PKZP position schedule
        /// </summary>
        [HttpGet("schedule")]
        [ProducesResponseType(typeof(PkzpScheduleDto), (int) HttpStatusCode.OK)] 
        public async Task<IActionResult> PkzpPositionSchedule([FromQuery] PkzpScheduleRequest request)
        {
            var schedule = await _mediator.Send(new PkzpScheduleQuery(
                request.Page,
                request.PerPage,
                request.OrderDirection,
                request.OrderBy,
                request.Search,
                request.PkzpPositionId));
            
            return Ok(schedule); 
        }
    }
}