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

        public static bool operator ==(TypedIdValueBase obj1, byte[] obj2)
        {
            if (Equals(obj1, null))
            {
                if (Equals(obj2, null))
                {
                    return true;
                }

                return false;
            }

            return obj1.Value.ToByteArray().Equals(obj2);
        }

        public static bool operator !=(TypedIdValueBase obj1, byte[] obj2)
        {
            return !(obj1 == obj2);
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is TypedIdValueBase other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(TypedIdValueBase other)
        {
            return other is { } && Value == other.Value;
        }
    }
}