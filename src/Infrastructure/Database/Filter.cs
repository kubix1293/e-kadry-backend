using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EKadry.Infrastructure.Database
{
    public abstract class Filter<T> where T : class
    {
        protected IQueryable<T> Query;
        private readonly string _orderBy;
        private readonly string _orderDirection;

        protected Filter(IQueryable<T> query, string orderBy = null, string orderDirection = null)
        {
            Query = query;
            _orderBy = orderBy != null ? orderBy.Trim() : "";
            _orderDirection = orderDirection != null && orderDirection.ToLower().Trim() == "desc" ? "OrderByDescending" : "OrderBy";

            ApplyOrder();
        }

        private void ApplyOrder()
        {
            var type = typeof(T);
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;
        
            var propertyInfo = type.GetProperty(_orderBy) ?? type.GetProperty("CreatedAt");
            if (propertyInfo == null) return;
            
            expr = Expression.Property(expr, propertyInfo);
            type = propertyInfo.PropertyType;

            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            Query = (IQueryable<T>) typeof(Queryable).GetMethods().Single(
                    method => method.Name == _orderDirection
                              && method.IsGenericMethodDefinition
                              && method.GetGenericArguments().Length == 2
                              && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] {Query, lambda});
        }

        public IQueryable<T> GetFilteredQuery()
        {
            return Query;
        }
    }
}