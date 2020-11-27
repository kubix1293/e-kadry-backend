using System.Collections.Generic;
using System.Security.Claims;

namespace EKadry.Infrastructure.Domain.Operators.Auth
{
    public interface IAuthService
    {
        string SecretKey { get; set; }
        bool IsTokenValidated { get; set; }
        string GenerateToken(IAuthContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}