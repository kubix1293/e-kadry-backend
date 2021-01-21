using System;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Domain
{
    public abstract class RepositoryBase<T> where T : DbContext
    {
        protected readonly T Context;
        private string _schemaName;
        private string _fullSchemaName;

        protected RepositoryBase(T context, string schemaName = null)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _schemaName = schemaName ?? throw new ArgumentNullException(nameof(schemaName));
            _fullSchemaName = SchemaNames.SchemaWithTable(schemaName) ?? "";
        }
    }
}