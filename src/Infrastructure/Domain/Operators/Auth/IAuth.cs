using System.Threading.Tasks;
using EKadry.Domain.DTO;

namespace EKadry.Infrastructure.Domain.Operators.Auth
{
    public interface IAuth
    {
        Task<string> Login(LoginDto forLoginDto);
    }
}