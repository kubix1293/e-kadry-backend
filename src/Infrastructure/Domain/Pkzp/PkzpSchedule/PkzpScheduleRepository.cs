using EKadry.Domain.Pkzp;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Pkzp.PkzpSchedule
{
    public class PkzpScheduleRepository : RepositoryBase<EKadryContext>, IPkzpRepository
    {
        public PkzpScheduleRepository(EKadryContext context) : base(context, SchemaNames.Contracts)
        {
        }
    }
}