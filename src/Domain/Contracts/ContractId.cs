using System;

namespace EKadry.Domain.Contracts
{
    public class ContractId : TypedIdValueBase
    {
        public ContractId(Guid value) : base(value)
        {
        }
        
        public ContractId(byte[] value) : base(value)
        {
        }
    }
}