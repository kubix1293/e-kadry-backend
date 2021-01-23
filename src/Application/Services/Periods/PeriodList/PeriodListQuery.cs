using System.Collections.Generic;
using EKadry.Application.Configuration.Queries;

namespace EKadry.Application.Services.Periods.PeriodList
{
    public class PeriodListQuery : IQuery<IList<PeriodListDto>>
    {
        public int SubMonths { get; }
        public int NextMonths { get; }

        public PeriodListQuery(
            int subMonths,
            int nextMonths
        )
        {
            SubMonths = subMonths;
            NextMonths = nextMonths;
        }
    }
}