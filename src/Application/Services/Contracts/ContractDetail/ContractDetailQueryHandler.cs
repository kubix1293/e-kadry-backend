using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Contracts;
using EKadry.Domain.Workers;

namespace EKadry.Application.Services.Contracts.ContractDetail
{
    public class ContractDetailQueryHandler : IQueryHandler<ContractDetailQuery, ContractDetailDto>
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ContractDetailQueryHandler(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<ContractDetailDto> Handle(ContractDetailQuery request, CancellationToken cancellationToken)
        {
            var worker = await _contractRepository.GetAsync(new Guid(request.Guid.ToByteArray()));

            return _mapper.Map<Contract, ContractDetailDto>(worker);
        }
    }
}