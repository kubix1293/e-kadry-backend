using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EKadry.Domain.Contracts;
using EKadry.Domain.Pagination;
using EKadry.Domain.Workers;
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
            var query = new ContractFilter(Context.Contract, commandOrderBy, commandOrderDirection, commandSearch)
                .GetFilteredQuery()
                .Include(x => x.Worker);

            return new Pagination<Contract>(query, commandPage, commandPerPage);
        }

        public async Task<Contract> GetAsync(Guid contractId)
        {
            var contract = await Context.Contract
                .Include(x => x.Worker)
                // .Where(x => x.Id == contractId)
                .FirstOrDefaultAsync();

            // contract.Worker = await Context.Worker.FirstOrDefaultAsync(x => x.Id == contract.IdWorker);

            return contract;
        }

        public async Task AddAsync(Contract contract)
        {
            await Context.Contract.AddAsync(contract);
            await Context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid workerId)
        {
            var worker = new Contract {Id = workerId};
            Context.Entry(worker).State = EntityState.Deleted;
            return await Context.SaveChangesAsync();
        }
    }
}