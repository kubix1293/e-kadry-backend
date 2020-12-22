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
            CancellationToken cancellationToken);
        Task<Contract> GetAsync(ContractId contractId);
        // Task AddAsync(Contract worker);
        Task<int> DeleteAsync(ContractId workerId);
    }
}