using System;
using EKadry.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Domain
{
    public abstract class RepositoryBase<T> where T : DbContext
    {
        protected readonly T Context;
        protected string SchemaName;
        protected string FullSchemaName;

        protected RepositoryBase(T context, string schemaName = null)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            SchemaName = schemaName ?? throw new ArgumentNullException(nameof(schemaName));
            FullSchemaName = SchemaNames.SchemaWithTable(schemaName) ?? "";
        }
    }
}