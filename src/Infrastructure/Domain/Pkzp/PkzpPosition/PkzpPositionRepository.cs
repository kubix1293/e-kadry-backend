using EKadry.Domain.Pkzp.Position;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Pkzp.PkzpPosition
{
    public class PkzpPositionRepository : RepositoryBase<EKadryContext>, IPkzpPositionRepository
    {
        public PkzpPositionRepository(EKadryContext context) : base(context, SchemaNames.PkzpPositions)
        {
        }
    }
}