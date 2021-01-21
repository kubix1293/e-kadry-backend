using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKadry.Domain.Contracts.JobPosition;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Domain.Contracts.JobPosition
{
    public class JobPositionRepository : RepositoryBase<EKadryContext>, IJobPositionRepository
    {
        public JobPositionRepository(EKadryContext context) : base(context, SchemaNames.JobPostions)
        {
        }

        public async Task<IList<EKadry.Domain.Contracts.JobPosition.JobPosition>> ToListAsync(string commandSearch = "", int commandPerPage = 5)
        {
            var query= Context.JobPosition.AsQueryable();

            if (commandSearch != "")
            {
                query = query.Where(p => p.Name.ToLower().Replace(" ", "").Contains(commandSearch.ToLower().Replace(" ", "")));
            }

            if (commandPerPage <= 1 || commandPerPage > 30)
            {
                query = query.Take(5);
            }
            else
            {
                query = query.Take(commandPerPage);
            }
            
            return await query.ToListAsync();
        }
    }
}