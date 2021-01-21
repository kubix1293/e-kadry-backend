using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Pkzp.Period
{
    public class PeriodRepository : RepositoryBase<EKadryContext>
    {
        public PeriodRepository(EKadryContext context) : base(context, SchemaNames.Period)
        {
        }
    }
}