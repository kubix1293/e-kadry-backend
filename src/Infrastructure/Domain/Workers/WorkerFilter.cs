using System.Linq;
using EKadry.Domain.Operators;
using EKadry.Domain.Workers;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Workers
{
    public sealed class WorkerFilter : Filter<Worker>
    {
        public WorkerFilter(
            IQueryable<Worker> query, 
            string orderBy = null, 
            string orderDirection = null, 
            string searchString = null)
            : base(query, orderBy, orderDirection)
        {
            Search(searchString);
        }

        private void Search(string search)
        {
            if (search != null)
            {
                Query = Query.Where(
                    s => s.FirstName.ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", "")) ||
                    s.LastName.ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", "")) ||
                    (s.FirstName + s.LastName).ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", ""))
                    );
            }
        }
    }
}