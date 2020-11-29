using EKadry.Application.Configuration.Queries.Common;
using EKadry.Domain.Pagination;

namespace EKadry.Application.Services.Workers.WorkerList
{
    public class WorkerListQuery : ListQuery<PagedList<WorkerListDto>>
    {
        public WorkerListQuery(
            int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search
        ) : base(page, perPage, orderDirection, orderBy, search)
        {
        }
    }
}