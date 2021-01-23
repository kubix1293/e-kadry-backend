using System.Threading.Tasks;
using EKadry.Domain.Pkzp.Period;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Pkzp.Period
{
    public class PeriodRepository : RepositoryBase<EKadryContext>, IPeriodRepository
    {
        public PeriodRepository(EKadryContext context) : base(context, SchemaNames.Period)
        {
        }

        public async Task AddAsync(EKadry.Domain.Pkzp.Period.Period period)
        {
            await Context.Period.AddAsync(period);
            await Context.SaveChangesAsync();
        }
    }
}