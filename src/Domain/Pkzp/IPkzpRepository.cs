using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EKadry.Domain.Pkzp.Position;

namespace EKadry.Domain.Pkzp
{
    public interface IPkzpRepository
    {
        Task<int> CreateAsync(Guid pkzpPositionId, PkzpPositionType pkzpPositionType, Guid periodId, Guid workerId, decimal amount, int installmentsCount = 0,
            decimal installmentAmount = 0);
        Task<int> PayoffPkzpAsync(Guid pkzpPositionId, decimal amount, PkzpPositionType pkzpPositionType, Guid workerId, Guid periodId, bool closed = false);
        Task<List<Pkzp>> GetByWorkerAsync(Guid workerId);
    }
}