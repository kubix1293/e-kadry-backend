using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace EKadry.Infrastructure.Domain.Operators.Auth
{
    public class JwtService : IAuthService
    {
        public string SecretKey { get; set; }
        public bool IsTokenValidated { get; set; }

        public JwtService(string secretKey)
        {
            SecretKey = secretKey;
        }

        public bool IsTokenValid(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Given token is null or empty.");
            }

            var tokenValidationParameters = GetTokenValidationParameters();

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var tokenValid = jwtSecurityTokenHandler.ValidateToken(
                    token,
                    tokenValidationParameters,
                    out var validatedToken);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GenerateToken(IAuthContainerModel model)
        {
            if (model == null || model.Claims == null || model.Claims.Length == 0)
            {
                throw new ArgumentException("Arguments to create token are not valid.");
            }

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(model.Claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(model.ExpireMinutes)),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), model.SecurityAlgorithm)
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }

        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Given token is null or empty.");
            }

            var tokenValidationParameters = GetTokenValidationParameters();

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters,
                    out var validatedToken);
                return tokenValid.Claims;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private SecurityKey GetSymmetricSecurityKey()
        {
            var symmetricKey = Convert.FromBase64String(SecretKey);

            return new SymmetricSecurityKey(symmetricKey);
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = GetSymmetricSecurityKey()
            };
        }
    }
}