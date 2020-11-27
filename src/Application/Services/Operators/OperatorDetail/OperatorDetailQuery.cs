using System;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Operators;

namespace EKadry.Application.Services.Operators.OperatorDetail
{
    public class OperatorDetailQuery : IQuery<OperatorDetailDto>
    {
        public readonly Guid OperatorId;

        public OperatorDetailQuery(Guid operatorId)
        {
            OperatorId = operatorId;
        }
    }
}