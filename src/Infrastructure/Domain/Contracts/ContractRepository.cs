using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EKadry.Domain.Contracts;
using EKadry.Domain.Pagination;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Domain.Contracts
{
    public class ContractRepository : RepositoryBase<EKadryContext>, IContractRepository
    {
        public ContractRepository(EKadryContext context) : base(context, SchemaNames.Contracts)
        {
        }

        public IPagination<Contract> ToListPaginated(
            int commandPage,
            int commandPerPage,
            string commandOrderDirection,
            string commandOrderBy,
            string commandSearch,
            CancellationToken cancellationToken)
        {
            var query = Context.Contract
                .Include(p => p.Worker)
                .AsQueryable();
            
            var filtered = new ContractFilter(query, commandOrderBy, commandOrderDirection, commandSearch)
                .GetFilteredQuery();

            return new Pagination<Contract>(filtered, commandPage, commandPerPage);
        }

        public async Task<Contract> GetAsync(ContractId contractId)
        {
            return await Context.Contract.Where(x => x.Id == contractId).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Contract contract)
        {
            await Context.Contract.AddAsync(contract);
            await Context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(ContractId workerId)
        {
            var worker = new Contract {Id = workerId};
            Context.Entry(worker).State = EntityState.Deleted;
            return await Context.SaveChangesAsync();
        }
    }
}