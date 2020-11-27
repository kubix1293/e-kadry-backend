using System.Reflection;
using EKadry.Application.Configuration.Commands;

namespace EKadry.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}