using System.Security.Claims;

namespace EKadry.Domain.Auth
{
    public interface IAuthContainerModel
    {
        Claim[] Claims { get; set; }
    }
}