using EKadry.Infrastructure.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace EKadry.API.Configuration
{
    public static class CorsConfiguration
    {
        internal static void CorsConfigure(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Production", builder => builder
                    .WithOrigins("https://e-kadry.tech")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
                
                options.AddPolicy("Development", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
        }
    }
}