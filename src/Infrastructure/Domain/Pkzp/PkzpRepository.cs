using EKadry.Domain.Pkzp;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Pkzp
{
    public class PkzpRepository : RepositoryBase<EKadryContext>, IPkzpRepository
    {
        public PkzpRepository(EKadryContext context) : base(context, SchemaNames.Pkzp)
        {
        }
    }
}