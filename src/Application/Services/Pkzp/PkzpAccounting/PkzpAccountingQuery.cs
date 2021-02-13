using System;
using EKadry.Application.Configuration.Queries.Common;
using EKadry.Domain.Pagination;

namespace EKadry.Application.Services.Pkzp.PkzpAccounting
{
    public class PkzpAccountingQuery : ListQuery<PagedList<PkzpAccountingDto>>
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