using System;
using System.Threading;
using System.Threading.Tasks;
using EKadry.Domain.Contracts;
using EKadry.Domain.Pagination;
using EKadry.Domain.Pkzp;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Domain.Pkzp.PkzpPosition
{
    public class PkzpPositionRepository : RepositoryBase<EKadryContext>, IPkzpRepository
    {
        public PkzpPositionRepository(EKadryContext context) : base(context, SchemaNames.Contracts)
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
            var query = Context.Contract;
            // var query = new PkzpFilter(Context.Contract, commandOrderBy, commandOrderDirection, commandSearch)
                // .GetFilteredQuery()
                // .Include(x => x.Worker);

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