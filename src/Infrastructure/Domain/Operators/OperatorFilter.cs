using System.Linq;
using EKadry.Domain.Operators;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Operators
{
    public sealed class OperatorFilter : Filter<Operator>
    {
        public OperatorFilter(
            IQueryable<Operator> query, 
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
                    s => s.Login.ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", "")) ||
                    s.FirstName.ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", "")) ||
                    s.LastName.ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", "")) ||
                    (s.FirstName + s.LastName).ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", ""))
                    );
            }
        }
    }
}