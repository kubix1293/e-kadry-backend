using System;
using EKadry.Domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EKadry.Infrastructure.Configuration
{
    public class TypedIdValueToByteConverter<TTypedIdValue> : ValueConverter<TTypedIdValue, byte[]>
        where TTypedIdValue : TypedIdValueBase
    {
        public TypedIdValueToByteConverter(ConverterMappingHints mappingHints = null)
            : base(id => id.Value.ToByteArray(), value => Create(value), mappingHints)
        {
        }

        private static TTypedIdValue Create(byte[] id) => Activator.CreateInstance(typeof(TTypedIdValue), id) as TTypedIdValue;
    }
}