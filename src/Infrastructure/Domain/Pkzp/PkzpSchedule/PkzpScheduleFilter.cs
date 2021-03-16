using System;
using System.Linq;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Pkzp.PkzpSchedule
{
    public sealed class PkzpScheduleFilter : Filter<EKadry.Domain.Pkzp.Schedule.PkzpSchedule>
    {
        public PkzpScheduleFilter(
            IQueryable<EKadry.Domain.Pkzp.Schedule.PkzpSchedule> query,
            string orderBy = null,
            string orderDirection = null,
            Guid? pkzpPositionId = null)
            : base(query, orderBy, orderDirection)
        {
            PkzpPositionId(pkzpPositionId);
        }

        private void PkzpPositionId(Guid? pkzpPositionId)
        {
            if (pkzpPositionId != null)
            {
                Query = Query.Where(x => x.IdPkzpPosition == (Guid) pkzpPositionId);
            }
        }
    }
}