using System;
using EKadry.Application.Configuration.Queries;
using EKadry.Application.Configuration.Queries.Common;
using EKadry.Domain.Pagination;

namespace EKadry.Application.Services.Pkzp.PkzpPositionFileqQuery
{
    public class PkzpPositionFileQuery : IQuery<PkzpPositionListDto>
    {

        public PkzpPositionFileQuery(
        ) : base(page, perPage, orderDirection, orderBy, search)
        {
            WorkerId = workerId;
        }
    }
}