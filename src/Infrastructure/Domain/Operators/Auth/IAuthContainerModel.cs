using System.Security.Claims;

namespace EKadry.Infrastructure.Domain.Operators.Auth
{
    public interface IAuthContainerModel
    {
        string SecretKey { get; set; }
        string SecurityAlgorithm { get; set; }
        int ExpireMinutes { get; set; }
        Claim[] Claims { get; set; }
    }
}