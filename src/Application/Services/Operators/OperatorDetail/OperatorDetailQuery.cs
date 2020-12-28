using System;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Operators;

namespace EKadry.Application.Services.Operators.OperatorDetail
{
    public class OperatorDetailQuery : IQuery<OperatorDetailDto>
    {
        public readonly Guid Guid;

        public OperatorDetailQuery(Guid operatorId)
        {
            Guid = operatorId;
        }
    }
}