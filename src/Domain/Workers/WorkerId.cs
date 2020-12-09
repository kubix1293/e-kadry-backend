using System;

namespace EKadry.Domain.Workers
{
    public class WorkerId : TypedIdValueBase
    {
        public WorkerId(Guid value) : base(value)
        {
        }
        
        public WorkerId(byte[] value) : base(value)
        {
        }
    }
}