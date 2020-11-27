using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace EKadry.Infrastructure.Domain.Operators.Auth
{
    public class JwtContainerModel : IAuthContainerModel
    {
        public string SecretKey { get; set; } = "er87jtf7re8ot547h98tgw364yft5h4078t9";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
        public int ExpireMinutes { get; set; } = 480;
        public Claim[] Claims { get; set; }
    }
}