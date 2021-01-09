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
            bool showInactiveContracts = true)
            : base(query, orderBy, orderDirection)
        {
            Search(searchString);
            InactiveContract(showInactiveContracts);
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
    }
}