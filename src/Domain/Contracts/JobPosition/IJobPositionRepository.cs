using System.Collections.Generic;

namespace EKadry.Domain.Contracts.JobPosition
{
    public interface IJobPositionRepository
    {
        IList<JobPosition> ToList(string commandSearch, int commandPerPage);
        IList<EnumApi> ToListEnum();
    }
}