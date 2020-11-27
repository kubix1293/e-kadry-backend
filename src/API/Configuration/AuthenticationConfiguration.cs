using System;
using EKadry.Infrastructure.Domain.Operators.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EKadry.API.Configuration
{
    public static class AuthenticationConfiguration
    {
        internal static void JwtServiceConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            // Console.WriteLine(configuration["ExpireMinutes"]);
            // services.AddSingleton<IAuthContainerModel>();
        }

        public static void JwtServiceConfigure(this IServiceCollection services, string configuration)
        {
            throw new System.NotImplementedException();
        }
    }
}