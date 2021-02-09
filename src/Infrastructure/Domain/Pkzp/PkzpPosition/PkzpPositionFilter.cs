using System;
using System.Linq;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Pkzp.PkzpPosition
{
    public sealed class PkzpPositionFilter : Filter<EKadry.Domain.Pkzp.Position.PkzpPosition>
    {
        public PkzpPositionFilter(
            IQueryable<EKadry.Domain.Pkzp.Position.PkzpPosition> query,
            string orderBy = null,
            string orderDirection = null,
            string searchString = null,
            Guid? workerId = null)
            : base(query, orderBy, orderDirection)
        {
            Search(searchString);
            Worker(workerId);
        }

        private void Search(string search)
        {
            if (search != null)
            {
                Query = Query.Where(
                    s => s.Worker.FirstName.ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", "")) ||
                         s.Worker.LastName.ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", "")) ||
                         (s.Worker.FirstName + s.Worker.LastName).ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", ""))
                );
            }
        }

        private void Worker(Guid? workerId)
        {
            if (workerId != null)
            {
                Query = Query.Where(x => x.IdWorker == (Guid) workerId);
            }
        }
    }
}