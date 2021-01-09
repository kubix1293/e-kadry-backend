using System;
using System.Threading;
using System.Threading.Tasks;
using EKadry.Domain.Pagination;

namespace EKadry.Domain.Contracts
{
    public interface IContractRepository
    {
        IPagination<Contract> ToListPaginated(int commandPage,
            int commandPerPage,
            string commandOrderDirection,
            string commandOrderBy,
            string commandSearch,
            bool showInactiveContracts,
            CancellationToken cancellationToken);
        Task<Contract> GetAsync(Guid contractId);
        // Task AddAsync(Contract worker);
        Task<int> DeleteAsync(Guid workerId);
    }
}