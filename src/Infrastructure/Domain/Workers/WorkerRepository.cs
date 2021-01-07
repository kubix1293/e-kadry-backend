using System;
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
            var query = new WorkerFilter(Context.Worker, commandOrderBy, commandOrderDirection, commandSearch)
                .GetFilteredQuery();

            return new Pagination<Worker>(query, commandPage, commandPerPage);
        }

        public async Task<Worker> GetAsync(Guid workerId)
        {
            var worker = await Context.Worker
                .FirstOrDefaultAsync(x => x.Id == workerId);

            worker.Contracts = await Context.Contract
                .Where(p => p.IdWorker == workerId)
                .ToListAsync();
            
            return worker;
        }

        public async Task AddAsync(Worker worker)
        {
            await Context.Worker.AddAsync(worker);
            await Context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid workerId)
        {
            var worker = new Worker {Id = workerId};
            Context.Entry(worker).State = EntityState.Deleted;
            return await Context.SaveChangesAsync();
        }
    }
}