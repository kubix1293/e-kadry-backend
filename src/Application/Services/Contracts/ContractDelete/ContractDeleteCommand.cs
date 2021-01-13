using System;
using EKadry.Application.Configuration.Commands;

namespace EKadry.Application.Services.Contracts.ContractDelete
{
    public class ContractDeleteCommand : CommandBase<int>
    {
        public ContractDeleteCommand(Guid id) : base(id)
        {
        }
    }
}