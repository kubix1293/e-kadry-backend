using System;
using System.Threading;
using EKadry.Domain.Pagination;

namespace EKadry.Domain.Pkzp.Schedule
{
    public interface IPkzpScheduleRepository
    {
        IPagination<PkzpSchedule> List(
            int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search,
            Guid pkzpPositionId,
            CancellationToken cancellationToken);
    }
}