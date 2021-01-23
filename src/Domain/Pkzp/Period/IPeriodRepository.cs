using System.Collections.Generic;
using System.Threading.Tasks;

namespace EKadry.Domain.Pkzp.Period
{
    public interface IPeriodRepository
    {
        Task AddAsync(Period period);
        Task<IList<Period>> ToListAsync(int querySubMonths, int queryNextMonths);
    }
}