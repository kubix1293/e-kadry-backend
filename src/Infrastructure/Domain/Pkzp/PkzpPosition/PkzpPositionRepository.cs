using System;
using System.Linq;
using System.Threading;
using EKadry.Domain.Pagination;
using EKadry.Domain.Pkzp.Position;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Domain.Pkzp.PkzpPosition
{
    public class PkzpPositionRepository : RepositoryBase<EKadryContext>, IPkzpPositionRepository
    {
        public PkzpPositionRepository(EKadryContext context) : base(context, SchemaNames.PkzpPositions)
        {
        }

        public IPagination<EKadry.Domain.Pkzp.Position.PkzpPosition> ToListPaginated(
            int commandPage,
            int commandPerPage,
            string commandOrderDirection,
            string commandOrderBy,
            string commandSearch,
            Guid workerId,
            CancellationToken cancellationToken)
        {
            var query = new PkzpPositionFilter(Context.PkzpPositions, commandOrderBy, commandOrderDirection, commandSearch, workerId)
                .GetFilteredQuery()
                .Include(x => x.Period);

            return new Pagination<EKadry.Domain.Pkzp.Position.PkzpPosition>(query, commandPage, commandPerPage);
        }

        public IPagination<EKadry.Domain.Pkzp.Position.PkzpPosition> ToAccountingPaginated(int page, int perPage, string orderDirection, string orderBy, string search, Guid periodId, CancellationToken cancellationToken)
        {
            var query = Context.PkzpPositions
                .Where(p => p.PkzpPositionType == PkzpPositionType.Contribution || p.PkzpPositionType == PkzpPositionType.Loan)
                .Include(p => p.Worker)
                .ThenInclude(w => w.PkzpContributions)
                .Include(p => p.PkzpSchedules);

            return new Pagination<EKadry.Domain.Pkzp.Position.PkzpPosition>(query, page, perPage);
        }
    }
}