using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EKadry.Domain.Pkzp.Position
{
    public interface IPkzpPositionRepository
    {
        Task<List<PkzpPosition>> ToListAsync(Guid workerId);
    }
}