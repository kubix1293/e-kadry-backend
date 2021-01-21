using System.Collections.Generic;
using System.Threading.Tasks;

namespace EKadry.Domain.Contracts.JobPosition
{
    public interface IJobPositionRepository
    {
        Task<IList<JobPosition>> ToListAsync(string commandSearch, int commandPerPage);
    }
}