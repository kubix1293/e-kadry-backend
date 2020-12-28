using System;
using EKadry.Application.Configuration.Queries;

namespace EKadry.Application.Services.Contracts.ContractDetail
{
    public class ContractDetailQuery : IQuery<ContractDetailDto>
    {
        public readonly Guid Guid;

        public ContractDetailQuery(Guid contractId)
        {
            Guid = contractId;
        }
    }
}