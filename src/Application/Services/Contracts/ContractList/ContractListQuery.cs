using System;
using EKadry.Application.Configuration.Queries.Common;
using EKadry.Domain.Pagination;

namespace EKadry.Application.Services.Contracts.ContractList
{
    public class ContractListQuery : ListQuery<PagedList<ContractListDto>>
    {
        public Guid? JobPosition { get; set; }
        public bool ShowInactiveContracts { get; }
        public DateTime? DateFrom { get; }
        public DateTime? DateTo { get; }
        
        public ContractListQuery(
            int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search,
            Guid? jobPosition,
            bool showInactiveContracts,
            DateTime? dateFrom,
            DateTime? dateTo
        ) : base(page, perPage, orderDirection, orderBy, search)
        {
            JobPosition = jobPosition;
            ShowInactiveContracts = showInactiveContracts;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}