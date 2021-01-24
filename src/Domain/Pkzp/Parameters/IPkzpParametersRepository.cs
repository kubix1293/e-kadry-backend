using System.Threading.Tasks;

namespace EKadry.Domain.Pkzp.Parameters
{
    public interface IPkzpParametersRepository
    {
        Task<PkzpParameters> Get();
    }
}