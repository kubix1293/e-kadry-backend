namespace EKadry.Application.Configuration.Queries.Common
{
    public abstract class ListQuery<T> : IQuery<T>
    {
        public int Page { get; }
        public int PerPage { get; }
        public string OrderDirection { get; }
        public string OrderBy { get; }
        public string Search { get; }
        
        public ListQuery(
            int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search
        )
        {
            Page = page;
            PerPage = perPage;
            OrderDirection = orderDirection;
            OrderBy = orderBy;
            Search = search;
        }
    }
}