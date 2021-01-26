using System;
using System.Linq;
using EKadry.Domain.Contracts;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Contracts
{
    public sealed class ContractFilter : Filter<Contract>
    {
        public ContractFilter(IQueryable<Contract> query,
            string orderBy = null,
            string orderDirection = null,
            string searchString = null,
            Guid? jobPosition = null,
            bool showInactiveContracts = true,
            DateTime? dateFrom = null,
            DateTime? dateTo = null,
            bool? hasPkzp = null) : base(query, orderBy, orderDirection)
        {
            Search(searchString);
            JobPosition(jobPosition);
            InactiveContract(showInactiveContracts);
            DateRange(dateFrom, dateTo);
            HasPkzp(hasPkzp);
        }

        private void Search(string search)
        {
            if (search != null)
            {
                Query = Query.Where(s =>
                    s.Worker.FirstName.ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", "")) ||
                    s.Worker.LastName.ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", "")) ||
                    (s.Worker.FirstName + s.Worker.LastName).ToLower().Replace(" ", "").Contains(search.ToLower().Replace(" ", ""))
                );
            }
        }

        private void JobPosition(Guid? jobPosition)
        {
            if (jobPosition != null)
            {
                Query = Query.Where(x => x.IdJobPosition == jobPosition);
            }
        }

        private void InactiveContract(bool showInactiveContracts)
        {
            if (!showInactiveContracts)
            {
                Query = Query.Where(c => c.EmployedAt <= DateTime.Now && (c.EmployedEndAt <= DateTime.Now || c.EmployedEndAt == null));
            }
        }

        private void DateRange(DateTime? dateFrom, DateTime? dateTo)
        {
            if (dateFrom != null && dateTo != null)
            {
                Query = Query.Where(x => x.EmployedAt >= dateFrom && x.EmployedAt <= dateTo);
            }
        }

        private void HasPkzp(bool? hasPkzp)
        {
            if (hasPkzp != null)
            {
                Query = Query.Where(x => x.IsPkzp);
            }
        }
    }
}