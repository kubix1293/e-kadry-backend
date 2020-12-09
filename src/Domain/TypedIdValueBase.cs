using System;

namespace EKadry.Domain
{
    public abstract class TypedIdValueBase : IEquatable<TypedIdValueBase>
    {
        public Guid Value { get; }

        protected TypedIdValueBase(Guid value)
        {
            Value = value;
        }
        
        protected TypedIdValueBase(byte[] value)
        {
            Value = new Guid(value);
        }

        public bool Equals(TypedIdValueBase other)
        {
            return other is { } && Value == other.Value;
        }
    }
}