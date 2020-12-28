using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Operators;
using EKadry.Domain.Pagination;

namespace EKadry.Application.Services.Operators.OperatorList
{
    public class OperatorListCommandHandler : IQueryHandler<OperatorListQuery, PagedList<OperatorListDto>>
    {
        private readonly IOperatorRepository _operatorRepository;
        private readonly IMapper _mapper;

        public OperatorListCommandHandler(IOperatorRepository operatorRepository, IMapper mapper)
        {
            _operatorRepository = operatorRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<OperatorListDto>> Handle(OperatorListQuery query, CancellationToken cancellationToken)
        {
            var operators = await _operatorRepository.ToListPaginated(
                query.Page,
                query.PerPage,
                query.OrderDirection,
                query.OrderBy,
                query.Search,
                cancellationToken).ToListAsync();
            
            return _mapper.Map<PagedList<Operator>, PagedList<OperatorListDto>>(operators);
        }
    }
}