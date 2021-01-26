using System;
using System.Collections.Generic;
using EKadry.Application.Configuration.Queries;

namespace EKadry.Application.Services.Pkzp.PkzpPositionList
{
    public class PkzpPositionListQuery : IQuery<List<PkzpPositionListDto>>
    {
        public Guid WorkerId { get; set; }

        public PkzpPositionListQuery(Guid workerId)
        {
            WorkerId = workerId;
        }
    }
}