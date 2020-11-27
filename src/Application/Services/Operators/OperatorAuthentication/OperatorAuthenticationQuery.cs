using EKadry.Application.Configuration.Queries;

namespace EKadry.Application.Services.Operators.OperatorAuthentication
{
    public class OperatorAuthenticationQuery: IQuery<OperatorAuthorizedDto>
    {
        public string Login { get; }
        public string Password { get; }
        
        public OperatorAuthenticationQuery(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}