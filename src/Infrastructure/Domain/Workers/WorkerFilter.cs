using System;
using System.Linq;
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
            string searchString = null,
            bool showInactiveContracts = false,
            bool? hasPkzp = null,
            Guid? jobPosition = null)
            : base(query, orderBy, orderDirection)
        {
            Search(searchString);
            InactiveContract(showInactiveContracts);
            HasPkzp(hasPkzp);
            JobPosition(jobPosition);
        }

        private void Search(string search)
        {
            if (search != null)
            {
                Query = Query.Where(
                    s => s.FirstName.ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", "")) ||
                         s.LastName.ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", "")) ||
                         (s.FirstName + s.LastName).ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", "")) ||
                         s.Pesel.Replace(" ", "").Contains(search.Replace(" ", "")) ||
                         s.DocumentNumber.Replace(" ", "").Contains(search.Replace(" ", ""))
                );
            }
        }

        private void InactiveContract(bool showInactiveContracts)
        {
            if (!showInactiveContracts)
            {
                Query = Query.Where(w => w.Contracts.Any(c =>
                    c.EmployedAt <= DateTime.Now && (c.EmployedEndAt <= DateTime.Now || c.EmployedEndAt == null)
                ));
            }
        }

        private void HasPkzp(bool? hasPkzp)
        {
            if (hasPkzp != null)
            {
                Query = Query.Where(w => w.Contracts.Any(c => c.IsPkzp));
            }
        }
        
        private void JobPosition(Guid? jobPosition)
        {
            if (jobPosition != null)
            {
                Query = Query.Where(w => w.Contracts.Any(x => x.IdJobPosition == jobPosition));
            }
        }
    }
}