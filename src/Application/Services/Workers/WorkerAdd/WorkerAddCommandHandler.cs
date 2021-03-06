using System.Threading;
using System.Threading.Tasks;
using EKadry.Application.Configuration.Commands;
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
            var @operator = Worker.Create(
                request.FirstName,
                request.LastName,
                request.Birthday,
                request.CityOfBirthday,
                request.Pesel,
                request.DocumentType,
                request.DocumentNumber,
                request.Gender,
                request.Street,
                request.PropertyNumber,
                request.ApartmentNumber,
                request.ZipCode,
                request.City,
                request.Country,
                request.ActNumber,
                request.MotherName,
                request.FatherName,
                request.Phone
                );
            await _operatorRepository.AddAsync(@operator);
            return new WorkerDto {Id = @operator.Id};
        }
    }
}