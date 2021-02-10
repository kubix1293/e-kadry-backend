using System.Collections.Generic;
using System.Security.Claims;

namespace EKadry.Domain.Auth
{
    public interface IAuthService
    {
        string GenerateToken(IAuthContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}