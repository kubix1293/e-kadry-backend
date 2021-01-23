using System.Threading.Tasks;

namespace EKadry.Domain.Pkzp.Period
{
    public interface IPeriodRepository
    {
        Task AddAsync(Period period);
    }
}