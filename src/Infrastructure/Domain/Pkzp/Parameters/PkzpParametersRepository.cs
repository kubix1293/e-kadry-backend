using System.Threading.Tasks;
using EKadry.Domain.Pkzp.Parameters;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Domain.Pkzp.Parameters
{
    public class PkzpParametersRepository : RepositoryBase<EKadryContext>, IPkzpParametersRepository 
    {
        public PkzpParametersRepository(EKadryContext context) : base(context, SchemaNames.PkzpParameters)
        {
        }

        public Task<PkzpParameters> Get()
        {
            return Context.PkzpParameters.FirstAsync();
        }
    }
}