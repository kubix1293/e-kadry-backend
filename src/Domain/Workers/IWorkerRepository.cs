using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EKadry.Domain.Pagination;

namespace EKadry.Domain.Workers
{
    public interface IWorkerRepository
    {
        IPagination<Worker> ToListPaginated(int commandPage,
            int commandPerPage,
            string commandOrderDirection,
            string commandOrderBy,
            string commandSearch,
            CancellationToken cancellationToken);
        Task<Worker> GetAsync(Guid workerId);
        Task<List<Worker>> Search(string searchKey, int limit);
        Task AddAsync(Worker worker);
        Task UpdateAsync(Worker worker);
        Task<int> DeleteAsync(Guid workerId);
    }
}