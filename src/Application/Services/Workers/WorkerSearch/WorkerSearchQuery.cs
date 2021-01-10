using System.Collections.Generic;
using EKadry.Application.Configuration.Queries;

namespace EKadry.Application.Services.Workers.WorkerSearch
{
    public class WorkerSearchQuery : IQuery<List<WorkerSearchDto>>
    {
        public string SearchKey { get; }
        public int Limit { get; }

        public WorkerSearchQuery(string searchKey, int limit)
        {
            SearchKey = searchKey;
            Limit = limit;
        }
    }
}