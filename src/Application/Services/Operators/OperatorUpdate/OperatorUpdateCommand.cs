using System;
using EKadry.Application.Configuration.Commands;
using MediatR;

namespace EKadry.Application.Services.Operators.OperatorUpdate
{
    public class OperatorUpdateCommand : CommandBase<Unit>
    {
        public Guid Id { get; }
        public string Login { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public bool Active { get; }
        public string Password { get; }

        public OperatorUpdateCommand(Guid id, string login, string firstName, string lastName, bool active, string password)
        {
            Id = id;
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            Active = active;
            Password = password;
        }
    }
}