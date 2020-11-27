using System.Collections.Generic;

namespace EKadry.Domain.Pagination
{
    public interface IPagedList<T>
    {
        List<T> Data { get; }
        int Page { get; }
        int PerPage { get; }
        int Total { get; }
        int TotalPages { get; }
    }
}