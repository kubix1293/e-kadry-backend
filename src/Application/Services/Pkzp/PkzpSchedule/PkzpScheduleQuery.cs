using System;
using EKadry.Application.Configuration.Queries.Common;
using EKadry.Domain.Pagination;

namespace EKadry.Application.Services.Pkzp.PkzpSchedule
{
    public class PkzpScheduleQuery : ListQuery<PagedList<PkzpScheduleDto>>
    {
        public Guid PkzpPositionId { get; }

        public PkzpScheduleQuery(
            int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search,
            Guid pkzpPositionId
        ) : base(page, perPage, orderDirection, orderBy, search)
        {
            PkzpPositionId = pkzpPositionId;
        }
    }
}