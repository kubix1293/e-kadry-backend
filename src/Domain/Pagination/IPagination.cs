using System.Threading.Tasks;

namespace EKadry.Domain.Pagination
{
    public interface IPagination<T> where T : class
    {
        Task<PagedList<T>> ToList();
    }
}