using System;

namespace EKadry.Domain.Operators
{
    public class OperatorId : TypedIdValueBase
    {
        public OperatorId(Guid value) : base(value)
        {
        }
        
        public OperatorId(byte[] value) : base(value)
        {
        }
    }
}