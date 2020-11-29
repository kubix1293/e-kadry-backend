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
            var query = Context.Worker.AsQueryable();
            var filtered = new WorkerFilter(query, commandOrderBy, commandOrderDirection, commandSearch).GetFilteredQuery();

            return new Pagination<Worker>(filtered, commandPage, commandPerPage);
        }

        public async Task<Worker> GetAsync(WorkerId id)
        {
            return await Context.Worker.Where(x => x.Id == id.Value.ToByteArray()).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Worker worker)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(WorkerId workerId)
        {
            return await Context.Database
                .ExecuteSqlInterpolatedAsync($"DELETE FROM KADRY.PRACOWNICY WHERE ID = {workerId.Value.ToByteArray()}");
        }
    }
}