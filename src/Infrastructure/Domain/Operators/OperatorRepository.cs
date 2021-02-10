using System;
using System.Collections.Generic;
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

        public async Task<Operator> GetAsync(Guid id)
        {
            return await Context.Operator.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Operator @operator)
        {
            await Context.Database.ExecuteSqlRawAsync(
                "BEGIN KADRY.OPER_SECURITY.ADD_OPER(:GUID, :LOGIN, :PASSWORD, :FIRST_NAME, :LAST_NAME); END;",
                new object[]
                {
                    new OracleParameter("GUID", @operator.Id.ToByteArray()),
                    new OracleParameter("LOGIN", @operator.Login),
                    new OracleParameter("PASSWORD", @operator.Password),
                    new OracleParameter("FIRST_NAME", @operator.FirstName),
                    new OracleParameter("LAST_NAME", @operator.LastName),
                });
        }
        
        public async Task UpdateAsync(Operator @operator)
        {
            var query = "UPDATE KADRY.OPER SET LOGIN = :LOGIN, IMIE = :FIRST_NAME, NAZWISKO = :LAST_NAME, AKTW = :ACTIVE WHERE LOGIN = :LOGIN";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter("LOGIN", @operator.Login),
                new OracleParameter("FIRST_NAME", @operator.FirstName),
                new OracleParameter("LAST_NAME", @operator.LastName),
                new OracleParameter("ACTIVE", @operator.Active ? 1 : 0),
            };
            
            if (@operator.Password != null)
            {
                query = "UPDATE KADRY.OPER SET LOGIN = :LOGIN, IMIE = :FIRST_NAME, NAZWISKO = :LAST_NAME, AKTW = :ACTIVE, PASSW = KADRY.OPER_SECURITY.GET_HASH(:LOGIN, :PASSWORD) WHERE LOGIN = :LOGIN";
                parameters.Add(new OracleParameter("PASSWORD", @operator.Password));
            }
            
            await Context.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public async Task<Operator> Authenticate(string login, string password)
        {
            return await Context.Operator
                .FromSqlInterpolated($"SELECT * FROM KADRY.OPER WHERE LOGIN = {login} AND PASSW = KADRY.OPER_SECURITY.GET_HASH({login}, {password})")
                .FirstOrDefaultAsync();
        }

        public async Task<int> DeleteAsync(Guid operatorId)
        {
            var @operator = new Operator {Id = operatorId};
            Context.Entry(@operator).State = EntityState.Deleted;
            return await Context.SaveChangesAsync();
        }
    }
}