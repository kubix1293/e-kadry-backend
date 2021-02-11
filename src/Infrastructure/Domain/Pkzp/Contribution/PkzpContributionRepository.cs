using System.Threading.Tasks;
using EKadry.Domain.Pkzp.Parameters;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Domain.Pkzp.Contribution
{
    public class PkzpContributionRepository : RepositoryBase<EKadryContext>, IPkzpParametersRepository 
    {
        public PkzpContributionRepository(EKadryContext context) : base(context, SchemaNames.PkzpParameters)
        {
        }

        public Task<PkzpParameters> Get()
        {
            return Context.PkzpParameters.FirstAsync();
        }
    }
}