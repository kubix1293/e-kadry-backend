using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EKadry.Domain.Pagination;

namespace EKadry.Domain.Workers
{
    public interface IWorkerRepository
    {
        IPagination<Worker> ToListPaginated(int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search,
            bool showInactiveContracts,
            bool? hasPkzp,
            Guid? jobPosition,
            CancellationToken cancellationToken);
        Task<Worker> GetAsync(Guid workerId);
        Task<List<Worker>> Search(string searchKey, int limit);
        Task AddAsync(Worker worker);
        Task UpdateAsync(Worker worker);
        Task<int> DeleteAsync(Guid workerId);
        IPagination<Worker> ToAccountingPaginated(
            int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search,
            Guid periodId,
            CancellationToken cancellationToken);
    }
}