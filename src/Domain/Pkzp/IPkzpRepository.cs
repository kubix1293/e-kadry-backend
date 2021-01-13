using System;
using System.Threading;
using System.Threading.Tasks;
using EKadry.Domain.Contracts;
using EKadry.Domain.Pagination;

namespace EKadry.Domain.Pkzp
{
    public interface IPkzpRepository
    {
        IPagination<Contract> ToListPaginated(int commandPage,
            int commandPerPage,
            string commandOrderDirection,
            string commandOrderBy,
            string commandSearch,
            CancellationToken cancellationToken);
        Task<Contract> GetAsync(Guid pkzpId);
        // Task AddAsync(Contract worker);
        Task<int> DeleteAsync(Guid pkzpId);
    }
}