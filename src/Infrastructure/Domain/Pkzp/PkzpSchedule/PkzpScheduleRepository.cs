using EKadry.Domain.Pkzp.Schedule;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Pkzp.PkzpSchedule
{
    public class PkzpScheduleRepository : RepositoryBase<EKadryContext>, IPkzpScheduleRepository
    {
        public PkzpScheduleRepository(EKadryContext context) : base(context, SchemaNames.PkzpSchedule)
        {
        }
    }
}