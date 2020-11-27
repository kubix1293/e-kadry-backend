using System.Threading;
using System.Threading.Tasks;
using EKadry.Domain.Pagination;

namespace EKadry.Domain.Operators
{
    public interface IOperatorRepository
    {
        IPagination<Operator> ToListPaginated(int commandPage,
            int commandPerPage,
            string commandOrderDirection,
            string commandOrderBy,
            string commandSearch,
            CancellationToken cancellationToken);
        Task<Operator> GetAsync(OperatorId operatorId);
        Task AddAsync(Operator @operator);
        Task<Operator> Authenticate(string login, string password);
        Task<int> DeleteAsync(OperatorId requestId);
    }
}