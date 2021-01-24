using System;
using System.Collections.Generic;
using EKadry.Application.Configuration.Queries;

namespace EKadry.Application.Services.Pkzp.PkzpSummary
{
    public class PkzpSummaryQuery: IQuery<List<PkzpSummaryDto>>
    {
        public Guid WorkerId { get; }
        
        public PkzpSummaryQuery(Guid workerId)
        {
            WorkerId = workerId;
        }
    }
}