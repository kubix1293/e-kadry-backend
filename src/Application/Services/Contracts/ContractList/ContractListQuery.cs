using EKadry.Application.Configuration.Queries.Common;
using EKadry.Domain.Pagination;

namespace EKadry.Application.Services.Contracts.ContractList
{
    public class ContractListQuery : ListQuery<PagedList<ContractListDto>>
    {
        public bool ShowInactiveContracts { get; }
        
        public ContractListQuery(
            int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search,
            bool showInactiveContracts
        ) : base(page, perPage, orderDirection, orderBy, search)
        {
            ShowInactiveContracts = showInactiveContracts;
        }
    }
}