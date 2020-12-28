using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Contracts;
using EKadry.Domain.Pagination;

namespace EKadry.Application.Services.Contracts.ContractList
{
    public class ContractListQueryHandler : IQueryHandler<ContractListQuery, PagedList<ContractListDto>>
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ContractListQueryHandler(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<ContractListDto>> Handle(ContractListQuery query, CancellationToken cancellationToken)
        {
            var contracts = await _contractRepository.ToListPaginated(
                query.Page,
                query.PerPage,
                query.OrderDirection,
                query.OrderBy,
                query.Search,
                cancellationToken).ToListAsync();
            
            return _mapper.Map<PagedList<Contract>, PagedList<ContractListDto>>(contracts);
        }
    }
}