using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EKadry.Domain.Pagination;
using EKadry.Domain.Workers;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Domain.Workers
{
    public class WorkerRepository : RepositoryBase<EKadryContext>, IWorkerRepository
    {
        public WorkerRepository(EKadryContext context) : base(context, SchemaNames.Workers)
        {
        }

        public IPagination<Worker> ToListPaginated(
            int commandPage,
            int commandPerPage,
            string commandOrderDirection,
            string commandOrderBy,
            string commandSearch,
            CancellationToken cancellationToken)
        {
            var query = Context.Worker
                .Include(p => p.Contracts)
                .AsQueryable();
            var filtered = new WorkerFilter(query, commandOrderBy, commandOrderDirection, commandSearch).GetFilteredQuery();

            var pag = new Pagination<Worker>(filtered, commandPage, commandPerPage);
            
            return pag;
        }

        public async Task<Worker> GetAsync(WorkerId workerId)
        {
            return await Context.Worker
                .Include(p => p.Contracts)
                .FirstOrDefaultAsync(x => x.Id == workerId);
        }

        public async Task AddAsync(Worker worker)
        {
            await Context.Worker.AddAsync(worker);
            await Context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(WorkerId workerId)
        {
            var worker = new Worker {Id = workerId};
            Context.Entry(worker).State = EntityState.Deleted;
            return await Context.SaveChangesAsync();
        }
    }
}