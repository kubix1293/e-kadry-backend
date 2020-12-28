using EKadry.Application.Configuration.Queries.Common;
using EKadry.Domain.Pagination;

namespace EKadry.Application.Services.Contracts.ContractList
{
    public class ContractListQuery : ListQuery<PagedList<ContractListDto>>
    {
        public ContractListQuery(
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