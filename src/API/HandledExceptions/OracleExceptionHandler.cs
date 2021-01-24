using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace EKadry.API.HandledExceptions
{
    public class OracleExceptionHandler : ProblemDetails
    {
        public OracleExceptionHandler(OracleException exception)
        {
            var messageMatch = Regex.Match(exception.Message, @"(?<=ORA-20201: ).*");
            var message = messageMatch.Value;

            Title = exception.ErrorCode.ToString();
            Type = exception.HelpLink;
            Status = StatusCodes.Status500InternalServerError;
            Detail = message.Length > 0 ? message : "Nie można wykonać tej operacji z powodu błędu serwera.";
        }
    }
}