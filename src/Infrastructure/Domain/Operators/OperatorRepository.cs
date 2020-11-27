using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EKadry.Domain.Operators;
using EKadry.Domain.Pagination;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace EKadry.Infrastructure.Domain.Operators
{
    public class OperatorRepository : RepositoryBase<EKadryContext>, IOperatorRepository
    {
        public OperatorRepository(EKadryContext context) : base(context, SchemaNames.Operators)
        {
        }

        public IPagination<Operator> ToListPaginated(
            int commandPage,
            int commandPerPage,
            string commandOrderDirection,
            string commandOrderBy,
            string commandSearch,
            CancellationToken cancellationToken)
        {
            var query = Context.Operator.AsQueryable();
            var filtered = new OperatorFilter(query, commandOrderBy, commandOrderDirection, commandSearch).GetFilteredQuery();

            return new Pagination<Operator>(filtered, commandPage, commandPerPage);
        }

        public async Task<Operator> GetAsync(OperatorId id)
        {
            return await Context.Operator.Where(x => x.Id == id.Value.ToByteArray()).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Operator @operator)
        {
            await Context.Database.ExecuteSqlRawAsync(
                "BEGIN KADRY.OPER_SECURITY.ADD_OPER(:GUID, :LOGIN, :PASSWORD, :FIRST_NAME, :LAST_NAME); END;",
                new object[]
                {
                    new OracleParameter("GUID", @operator.Id.Value.ToByteArray()),
                    new OracleParameter("LOGIN", @operator.Login),
                    new OracleParameter("PASSWORD", @operator.Password),
                    new OracleParameter("FIRST_NAME", @operator.FirstName),
                    new OracleParameter("LAST_NAME", @operator.LastName),
                });
        }

        public async Task<Operator> Authenticate(string login, string password)
        {
            return await Context.Operator
                .FromSqlInterpolated($"SELECT * FROM KADRY.OPER WHERE LOGIN = {login} AND PASSW = KADRY.OPER_SECURITY.GET_HASH({login}, {password})")
                .FirstOrDefaultAsync();
        }

        public async Task<int> DeleteAsync(OperatorId operatorId)
        {
            return await Context.Database
                .ExecuteSqlInterpolatedAsync($"DELETE FROM KADRY.OPER WHERE ID = {operatorId.Value.ToByteArray()}");
        }
    }
}