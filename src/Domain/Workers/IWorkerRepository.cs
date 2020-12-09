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
        Task<Worker> GetAsync(WorkerId workerId);
        Task AddAsync(Worker worker);
        Task<int> DeleteAsync(WorkerId requestId);
    }
}