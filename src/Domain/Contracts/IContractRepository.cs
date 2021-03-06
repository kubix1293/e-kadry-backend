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
            Guid? jobPosition,
            bool commandShowInactiveContracts,
            DateTime? commandDateFrom,
            DateTime? commandDateTo,
            bool? queryHasPkzp,
            CancellationToken cancellationToken);

        Task<Contract> GetAsync(Guid contractId);
        Task AddAsync(Contract contract);
        Task<int> DeleteAsync(Guid workerId);
        Task UpdateAsync(Contract contract);
    }
}