using System;
using EKadry.Application.Configuration.Queries.Common;
using EKadry.Domain.Pagination;

namespace EKadry.Application.Services.Pkzp.PkzpPositionList
{
    public class PkzpPositionListQuery : ListQuery<PagedList<PkzpPositionListDto>>
    {
        public Guid WorkerId { get; set; }

        public PkzpPositionListQuery(
            int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search,
            Guid workerId
        ) : base(page, perPage, orderDirection, orderBy, search)
        {
            WorkerId = workerId;
        }
    }
}