using EKadry.Domain.Pkzp;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Pkzp.PkzpPosition
{
    public class PkzpPositionRepository : RepositoryBase<EKadryContext>, IPkzpRepository
    {
        public PkzpPositionRepository(EKadryContext context) : base(context, SchemaNames.PkzpPositions)
        {
        }
    }
}