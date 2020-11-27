using EKadry.Application.Configuration.Commands;

namespace EKadry.Application.Services.Operators.OperatorAdd
{
    public class OperatorAddCommand : CommandBase<OperatorDto>
    {
        public string Login { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public OperatorAddCommand(string login, string password, string firstName, string lastName)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}