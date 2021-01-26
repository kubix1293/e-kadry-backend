using System;
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
            int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search,
            bool showInactiveContracts,
            bool? hasPkzp,
            Guid? jobPosition,
            CancellationToken cancellationToken)
        {
            var query
                = new WorkerFilter(Context.Worker, orderBy, orderDirection, search, showInactiveContracts, hasPkzp, jobPosition)
                    .GetFilteredQuery()
                    .Include(x => x.Contracts);

            return new Pagination<Worker>(query, page, perPage);
        }

        public async Task<Worker> GetAsync(Guid workerId)
        {
            var worker = await Context.Worker
                .Include(x => x.Contracts)
                .FirstOrDefaultAsync(x => x.Id == workerId);

            return worker;
        }

        public async Task<List<Worker>> Search(string searchKey, int limit)
        {
            var worker = Context.Worker
                .Where(s => s.FirstName.ToLower().Replace(" ", "").Contains(searchKey.ToLower().Replace(" ", "")) ||
                            s.LastName.ToLower().Replace(" ", "").Contains(searchKey.ToLower().Replace(" ", "")) ||
                            (s.FirstName + s.LastName).ToLower().Replace(" ", "").Contains(searchKey.ToLower().Replace(" ", "")))
                .Take(limit);

            return await worker.ToListAsync();
        }

        public async Task AddAsync(Worker worker)
        {
            await Context.Worker.AddAsync(worker);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Worker worker)
        {
            Context.Worker.Attach(worker);
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