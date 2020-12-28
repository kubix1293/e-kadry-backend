using System.Threading.Tasks;

namespace EKadry.Domain.Pagination
{
    public interface IPagination<T> where T : class
    {
        PagedList<T> ToList();
        Task<PagedList<T>> ToListAsync();
    }
}