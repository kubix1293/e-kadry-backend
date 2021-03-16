using System;
using System.Threading;
using EKadry.Domain.Pagination;
using EKadry.Domain.Pkzp.Schedule;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Domain.Pkzp.PkzpSchedule
{
    public class PkzpScheduleRepository : RepositoryBase<EKadryContext>, IPkzpScheduleRepository
    {
        public PkzpScheduleRepository(EKadryContext context) : base(context, SchemaNames.PkzpSchedule)
        {
        }

        public IPagination<EKadry.Domain.Pkzp.Schedule.PkzpSchedule> List(
            int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search,
            Guid pkzpPositionId,
            CancellationToken cancellationToken)
        {
            var query = new PkzpScheduleFilter(Context.PkzpSchedules, orderBy, orderDirection, pkzpPositionId)
                .GetFilteredQuery()
                .Include(x => x.Period);

            return new Pagination<EKadry.Domain.Pkzp.Schedule.PkzpSchedule>(query, page, perPage);
        }
    }
}