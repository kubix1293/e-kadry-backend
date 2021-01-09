using System;
using System.Linq;
using EKadry.Domain.Contracts;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Contracts
{
    public sealed class ContractFilter : Filter<Contract>
    {
        public ContractFilter(
            IQueryable<Contract> query,
            string orderBy = null,
            string orderDirection = null,
            string searchString = null,
            bool showInactiveContracts = true,
            DateTime? dateFrom = null,
            DateTime? dateTo = null
        ) : base(query, orderBy, orderDirection)
        {
            Search(searchString);
            InactiveContract(showInactiveContracts);
            DateRange(dateFrom, dateTo);
        }

        private void Search(string search)
        {
        }

        private void InactiveContract(bool showInactiveContracts)
        {
            if (!showInactiveContracts)
            {
                Query = Query.Where(x => x.EmployedEndAt == null);
            }
        }
        
        private void DateRange(DateTime? dateFrom, DateTime? dateTo)
        {
            if (dateFrom != null && dateTo != null)
            {
                Query = Query.Where(x => x.EmployedAt >= dateFrom && x.EmployedAt <= dateTo);
            }
        }
    }
}