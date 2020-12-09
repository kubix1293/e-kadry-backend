using System.Threading;
using System.Threading.Tasks;
using EKadry.Application.Configuration.Commands;
using EKadry.Application.Services.Operators.OperatorAdd;
using EKadry.Domain.Operators;
using EKadry.Domain.Workers;

namespace EKadry.Application.Services.Workers.WorkerAdd
{
    public class WorkerAddCommandHandler : ICommandHandler<WorkerAddCommand, WorkerDto>
    {
        private readonly IWorkerRepository _operatorRepository;

        public WorkerAddCommandHandler(IWorkerRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public async Task<WorkerDto> Handle(WorkerAddCommand request, CancellationToken cancellationToken)
        {
            var @operator = Worker.CreateWorker(
                request.FirstName,
                request.LastName,
                request.Birthday,
                request.CityOfBirthday,
                request.Pesel,
                request.DocumentType,
                request.DocumentNumber,
                request.Gender,
                request.IdCity,
                request.Street,
                request.PropertyNumber,
                request.ApartmentNumber,
                request.ActNumber,
                request.MotherName,
                request.FatherName,
                request.Phone
                );
            await _operatorRepository.AddAsync(@operator);
            return new WorkerDto {Id = @operator.Id.Value};
        }
    }
}