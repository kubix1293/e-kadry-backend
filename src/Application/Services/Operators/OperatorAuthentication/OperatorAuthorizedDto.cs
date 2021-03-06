using System;

namespace EKadry.Application.Services.Operators.OperatorAuthentication
{
    public class AuthorizedDto
    {
        public string Token;
        public string TokenType;
        public OperatorAuthorizedDto Operator;
    }
    
    public class OperatorAuthorizedDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}