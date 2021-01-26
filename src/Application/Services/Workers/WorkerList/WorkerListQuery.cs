using System;
using EKadry.Application.Configuration.Queries.Common;
using EKadry.Domain.Pagination;

namespace EKadry.Application.Services.Workers.WorkerList
{
    public class WorkerListQuery : ListQuery<PagedList<WorkerListDto>>
    {
        public bool ShowInactiveContracts { get; }
        public bool? HasPkzp { get; }
        public Guid? JobPosition { get; }

        public WorkerListQuery(
            int page,
            int perPage,
            string orderDirection,
            string orderBy,
            string search,
            bool showInactiveContracts,
            bool? hasPkzp,
            Guid? jobPosition
        ) : base(page, perPage, orderDirection, orderBy, search)
        {
            ShowInactiveContracts = showInactiveContracts;
            HasPkzp = hasPkzp;
            JobPosition = jobPosition;
        }
    }
}