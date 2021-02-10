using System;
using System.Collections.Generic;
using System.Net;
using EKadry.Domain;
using EKadry.Domain.Pkzp;
using EKadry.Domain.Pkzp.Position;
using EKadry.Domain.Workers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EKadry.API.Http
{
    [Authorize]
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
                {nameof(PkzpType), EnumHelper<PkzpType>.GetMaps(typeof(PkzpType))},
                {nameof(PkzpPositionType), EnumHelper<PkzpPositionType>.GetMaps(typeof(PkzpPositionType))},
            };

            return Ok(list);
        }
    }
}