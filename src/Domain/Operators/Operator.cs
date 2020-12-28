using System;

namespace EKadry.Domain.Operators
{
    public class Operator : Entity, IAggregateRoot
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static Operator CreateOperator(string login, string password, string firstName, string lastName)
        {
            return new Operator()
            {
                Id = Guid.NewGuid(),
                Login = login,
                Password = password,
                FirstName = firstName,
                LastName = lastName
            };
        }
    }
}