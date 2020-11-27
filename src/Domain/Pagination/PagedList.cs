using System;
using System.Collections.Generic;
using EKadry.Domain.Operators;

namespace EKadry.Domain.Pagination
{
    public class PagedList<T> : IPagedList<T>
    {
        public List<T> Data { get; }
        public int Page { get; }
        public int PerPage { get; }
        public int Total { get; }
        public int TotalPages { get; }

        public PagedList(List<T> data, int page, int perPage, int total)
        {
            Data = data;
            Page = page;
            PerPage = perPage;
            Total = total;
            TotalPages = Convert.ToInt32(Math.Ceiling((double) total / perPage));
        }
    }
}