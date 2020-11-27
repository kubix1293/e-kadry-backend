using System;
using EKadry.Domain.Operators;

namespace EKadry.Application.Services.Operators.OperatorAuthentication
{
    public class AuthorizedDto
    {
        public string Token;
        public string TokenType;
        public string ExpiresAt;
        public OperatorAuthorizedDto Operator;
    }
    
    public class OperatorAuthorizedDto
    {
        public OperatorId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}