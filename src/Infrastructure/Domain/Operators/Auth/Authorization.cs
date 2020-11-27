using System;
using System.Linq;
using System.Security.Claims;

namespace EKadry.Infrastructure.Domain.Operators.Auth
{
    public class Authorization
    {
        public Authorization()
        {
            IAuthContainerModel model = GetJwtContainerModel("Moshe Binieli", "mmoshikoo@gmail.com");
            var authService = new JwtService(model.SecretKey);

            var token = authService.GenerateToken(model);

            if (!authService.IsTokenValid(token))
                throw new UnauthorizedAccessException();
            else
            {
                var claims = authService.GetTokenClaims(token).ToList();

                Console.WriteLine(claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name))?.Value);
                Console.WriteLine(claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Email))?.Value);
            }
        }

        private static JwtContainerModel GetJwtContainerModel(string name, string email)
        {
            return new JwtContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email)
                }
            };
        }
    }
}