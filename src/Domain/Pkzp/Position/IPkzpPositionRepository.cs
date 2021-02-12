using System;
using System.Threading;
using EKadry.Domain.Pagination;

namespace EKadry.Domain.Pkzp.Position
{
    public interface IPkzpPositionRepository
    {
        IPagination<PkzpPosition> ToListPaginated(int commandPage,
            int commandPerPage,
            string commandOrderDirection,
            string commandOrderBy,
            string commandSearch,
            Guid workerId,
            CancellationToken cancellationToken);

        IPagination<PkzpPosition> ToAccountingPaginated(
            int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search,
            Guid periodId,
            CancellationToken cancellationToken);
    }
}