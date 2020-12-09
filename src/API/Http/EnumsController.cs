using System;
using System.Collections.Generic;
using System.Net;
using EKadry.Domain;
using EKadry.Domain.Workers;
using Microsoft.AspNetCore.Mvc;

namespace EKadry.API.Http
{
    [ApiController]
    [Route("api/enums")]
    public class EnumsController : ControllerBase
    {
        /// <summary>
        /// Get all enums
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Enum[]), (int) HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var list = new Dictionary<string, IList<EnumApi>>
            {
                {nameof(DocumentType), EnumHelper<DocumentType>.GetMaps(typeof(DocumentType))},
                {nameof(Gender), EnumHelper<Gender>.GetMaps(typeof(Gender))},
            };

            return Ok(list);
        }
    }
}