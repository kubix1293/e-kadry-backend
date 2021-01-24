using System;
using System.Threading.Tasks;
using EKadry.Domain.Pkzp;
using EKadry.Domain.Pkzp.Position;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace EKadry.Infrastructure.Domain.Pkzp
{
    public class PkzpRepository : RepositoryBase<EKadryContext>, IPkzpRepository
    {
        public PkzpRepository(EKadryContext context) : base(context, SchemaNames.Pkzp)
        {
        }
        
        public async Task<int> CreateAsync(Guid pkzpPositionId, PkzpPositionType pkzpPositionType, Guid periodId, Guid workerId, decimal amount, int installmentsCount,
            decimal installmentAmount)
        {
            return await Context.Database.ExecuteSqlRawAsync(
                "BEGIN KADRY.PKZP_PACK.PKZP_INSERT(:PKZP_POSITION_GUID, :TYPE, :PERIOD, :WORKER, :AMOUNT, :INSTALLMENTS_COUNT, :INSTALLMENT_AMOUNT); END;",
                new object[]
                {
                    new OracleParameter("PKZP_POSITION_GUID", pkzpPositionId.ToByteArray()),
                    new OracleParameter("TYPE", (int) pkzpPositionType),
                    new OracleParameter("PERIOD", periodId.ToByteArray()),
                    new OracleParameter("WORKER", workerId.ToByteArray()),
                    new OracleParameter("AMOUNT", amount),
                    new OracleParameter("INSTALLMENTS_COUNT", installmentsCount),
                    new OracleParameter("INSTALLMENT_AMOUNT", installmentAmount)
                });
        }
        
        public async Task<int> PayoffPkzpAsync(Guid pkzpPositionId, decimal amount, PkzpPositionType pkzpPositionType, Guid workerId, Guid periodId, bool closed = false)
        {
            return await Context.Database.ExecuteSqlRawAsync(
                "BEGIN KADRY.PKZP_PACK.PKZP_SPLATY(:PKZP_POSITION_GUID, :AMOUNT, :TYPE, :WORKER, :PERIOD, :CLOSED, :INSTALLMENT_AMOUNT); END;",
                new object[]
                {
                    new OracleParameter("PKZP_POSITION_GUID", pkzpPositionId.ToByteArray()),
                    new OracleParameter("AMOUNT", amount),
                    new OracleParameter("TYPE", pkzpPositionType),
                    new OracleParameter("PERIOD", periodId.ToByteArray()),
                    new OracleParameter("WORKER", workerId.ToByteArray()),
                    new OracleParameter("CLOSED", closed),
                });
        }
        
        public async Task<EKadry.Domain.Pkzp.Pkzp> GetByWorkerAsync(Guid workerId)
        {
            return await Context.Pkzp
                .Include(x => x.Worker)
                .FirstAsync(x => x.IdWorker == workerId);
        }
    }
}