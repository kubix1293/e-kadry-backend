using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EKadry.Domain.Auth;
using Microsoft.IdentityModel.Tokens;

namespace EKadry.Infrastructure.Auth
{
    public class JwtService : IAuthService
    {
        private readonly string _secretKey;
        private readonly string _securityAlgorithm;
        private readonly int _expireMinutes;

        public JwtService(string secretKey, int expireMinutes = 720, string securityAlgorithm = SecurityAlgorithms.HmacSha256Signature)
        {
            _secretKey = secretKey;
            _expireMinutes = expireMinutes;
            _securityAlgorithm = securityAlgorithm;
        }

        public bool IsTokenValid(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Given token is null or empty.");
            }

            var tokenValidationParameters = GetTokenValidationParameters(_secretKey);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out _);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GenerateToken(IAuthContainerModel model)
        {
            if (model?.Claims == null || model.Claims.Length == 0)
            {
                throw new ArgumentException("Arguments to create token are not valid.");
            }

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(model.Claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_expireMinutes)),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(_secretKey), _securityAlgorithm)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }

        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Given token is null or empty.");
            }

            var tokenValidationParameters = GetTokenValidationParameters(_secretKey);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out _);
            
            return tokenValid.Claims;
        }

        private static SecurityKey GetSymmetricSecurityKey(string secretKey)
        {
            var symmetricKey = Convert.FromBase64String(secretKey);

            return new SymmetricSecurityKey(symmetricKey);
        }

        public static TokenValidationParameters GetTokenValidationParameters(string secretKey)
        {
            return new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSymmetricSecurityKey(secretKey),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }
    }
}