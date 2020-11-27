using EKadry.Application.Configuration.Queries.Common;
using EKadry.Domain.Pagination;

namespace EKadry.Application.Services.Operators.OperatorList
{
    public class OperatorListQuery : ListQuery<PagedList<OperatorListDto>>
    {
        public OperatorListQuery(
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