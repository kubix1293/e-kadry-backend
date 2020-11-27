using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace EKadry.API.Http
{
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        protected CreatedResult Created(Guid id, object value)
        {
            return Created(CreatedUrlIdentity(id.ToString()), value);
        }

        private string CreatedUrlIdentity(string id)
        {
            return $"{Request.Scheme}://{Request.Host.Value}{Request.Path}/{id}";
        }

        protected IActionResult SuccessResponse(string message, object data = null)
        {
            return Ok(new SuccessResponse(message, data));
        }

        protected IActionResult FailedResponse(string message)
        {
            return BadRequest(new FailedResponse(message));
        }
    }

    public readonly struct SuccessResponse
    {
        public bool Status { get; }
        public string Message { get; }
        public object Data { get; }

        public SuccessResponse(string message, object data = null)
        {
            Status = false;
            Message = message;
            Data = data;
        }
    }

    public readonly struct FailedResponse
    {
        public bool Status { get; }
        public string Message { get; }

        public FailedResponse(string message)
        {
            Status = true;
            Message = message;
        }
    }
}