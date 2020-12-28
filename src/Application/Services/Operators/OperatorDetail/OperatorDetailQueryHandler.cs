using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EKadry.Application.Configuration.Queries;
using EKadry.Domain.Operators;

namespace EKadry.Application.Services.Operators.OperatorDetail
{
    public class OperatorDetailQueryHandler : IQueryHandler<OperatorDetailQuery, OperatorDetailDto>
    {
        private readonly IOperatorRepository _operatorRepository;
        private readonly IMapper _mapper;

        public OperatorDetailQueryHandler(IOperatorRepository operatorRepository, IMapper mapper)
        {
            _operatorRepository = operatorRepository;
            _mapper = mapper;
        }

        public async Task<OperatorDetailDto> Handle(OperatorDetailQuery request, CancellationToken cancellationToken)
        {
            var operators = await _operatorRepository.GetAsync(new Guid(request.Guid.ToByteArray()));

            return _mapper.Map<Operator, OperatorDetailDto>(operators);
        }
    }
}