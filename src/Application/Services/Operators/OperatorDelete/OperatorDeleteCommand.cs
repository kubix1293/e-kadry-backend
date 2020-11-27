using System;
using EKadry.Application.Configuration.Commands;

namespace EKadry.Application.Services.Operators.OperatorDelete
{
    public class OperatorDeleteCommand : CommandBase<int>
    {
        public OperatorDeleteCommand(Guid id) : base(id)
        {
        }
    }
}