using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKadry.Domain.Pkzp.Position;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Domain.Pkzp.PkzpPosition
{
    public class PkzpPositionRepository : RepositoryBase<EKadryContext>, IPkzpPositionRepository
    {
        public PkzpPositionRepository(EKadryContext context) : base(context, SchemaNames.PkzpPositions)
        {
        }

        public async Task<List<EKadry.Domain.Pkzp.Position.PkzpPosition>> ToListAsync(Guid workerId)
        {
            return await Context.PkzpPositions.Where(x => x.IdWorker == workerId).ToListAsync();
        }
    }
}