using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKadry.Domain.Pkzp.Period;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IList<EKadry.Domain.Pkzp.Period.Period>> ToListAsync(int querySubMonths, int queryNextMonths)
        {
            var query = Context.Period.AsQueryable();

            query = query.Where(x => 
                x.DateFrom >= DateTime.Now.AddMonths(-(querySubMonths + 1)) &&
                x.DateFrom <= DateTime.Now.AddMonths(querySubMonths + queryNextMonths - 1));

            return await query.ToListAsync();
        }
    }
}