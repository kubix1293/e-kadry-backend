using System;
using System.Net.Http;
using EKadry.API.HandledExceptions;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;

namespace EKadry.API.Configuration
{
    public static class ErrorHandlerConfiguration
    {
        private static bool _isProduction;

        internal static void ConfigureProblemDetails(this IServiceCollection services, bool isProduction)
        {
            _isProduction = isProduction;
            services.AddProblemDetails(ConfigureProblemDetails);
        }
        
        private static void ConfigureProblemDetails(ProblemDetailsOptions options)
        {
            options.IncludeExceptionDetails = (ctx, ex) => !_isProduction;

            options.Rethrow<NotSupportedException>();
            options.Map<OracleException>(ex => new OracleExceptionHandler(ex));
            options.MapToStatusCode<NotImplementedException>(StatusCodes.Status501NotImplemented);
            options.MapToStatusCode<HttpRequestException>(StatusCodes.Status503ServiceUnavailable);
            options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
        }
    }
}