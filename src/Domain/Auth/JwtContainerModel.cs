using System.Security.Claims;

namespace EKadry.Domain.Auth
{
    public class JwtContainerModel : IAuthContainerModel
    {
        public Claim[] Claims { get; set; }
    }
}