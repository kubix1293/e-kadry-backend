using System.Collections.Generic;
using EKadry.Application.Configuration.Queries;

namespace EKadry.Application.Services.JobPositions.OperatorList
{
    public class JobPositionListQuery : IQuery<IList<JobPositionListDto>>
    {
        public string Search { get; }
        public int PerPage { get; }

        public JobPositionListQuery(
            string search,
            int perPage
        )
        {
            Search = search;
            PerPage = perPage;
        }
    }
}