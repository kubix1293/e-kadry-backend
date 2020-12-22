using System.Linq;
using EKadry.Domain.Contracts;
using EKadry.Domain.Workers;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Contracts
{
    public sealed class ContractFilter : Filter<Contract>
    {
        public ContractFilter(
            IQueryable<Contract> query, 
            string orderBy = null, 
            string orderDirection = null, 
            string searchString = null)
            : base(query, orderBy, orderDirection)
        {
        }

        private void Search(string search)
        {
        }
    }
}