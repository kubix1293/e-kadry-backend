using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EKadry.Infrastructure.Configuration
{
    public class IntToBooleanConverter : ValueConverter<bool, int>
    {
        public IntToBooleanConverter(ConverterMappingHints mappingHints = null)
            : base(value => value ? 1 : 0, x => x == 1, mappingHints)
        {
        }
    }
}