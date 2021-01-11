using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EKadry.Domain.Contracts.JobPosition;
using EKadry.Infrastructure.Database;

namespace EKadry.Infrastructure.Domain.Contracts.JobPosition
{
    public class JobPositionRepository : RepositoryBase<EKadryContext>, IJobPositionRepository
    {
        private readonly IMapper _mapper;

        public JobPositionRepository(EKadryContext context, IMapper mapper) : base(context, SchemaNames.JobPostions)
        {
            _mapper = mapper;
        }

        public IList<EKadry.Domain.Contracts.JobPosition.JobPosition> ToList(string commandSearch = "", int commandPerPage = default)
        {
            var query = Context.JobPosition;

            if (commandSearch != "")
            {
                query.Where(p => p.Name.ToLower().Replace(" ", "") == commandSearch.ToLower().Replace(" ", ""));
            }
            
            return query.ToList();
        }

        public IList<EnumApi> ToListEnum()
        {
            return _mapper.Map<IList<EKadry.Domain.Contracts.JobPosition.JobPosition>, IList<EnumApi>>(ToList());
        }
    }
}