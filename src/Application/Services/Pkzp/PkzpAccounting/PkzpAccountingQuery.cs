using System;
using EKadry.Application.Configuration.Queries.Common;
using EKadry.Domain.Pagination;
using EKadry.Domain.Pkzp.Position;
using EKadry.Domain.Workers;

namespace EKadry.Application.Services.Pkzp.PkzpAccounting
{
    // WorkerPkzpAccountingDto
    public class PkzpAccountingQuery : ListQuery<PagedList<PkzpPosition>>
    {
        public Guid PeriodId { get; }

        public PkzpAccountingQuery(
            int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search,
            Guid periodId
        ) : base(page, perPage, orderDirection, orderBy, search) 
        {
            PeriodId = periodId;
        }
    }
}