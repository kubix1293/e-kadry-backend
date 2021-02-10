using EKadry.Infrastructure.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace EKadry.API.Configuration
{
    public static class AuthenticationConfiguration
    {
        internal static void AuthenticationConfigure(this IServiceCollection services, string token)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = JwtService.GetTokenValidationParameters(token);
            });
        }
    }
}