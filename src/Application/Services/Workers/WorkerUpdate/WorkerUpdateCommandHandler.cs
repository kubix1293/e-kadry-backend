using System.Threading;
using System.Threading.Tasks;
using EKadry.Application.Configuration.Commands;
using EKadry.Domain.Workers;
using MediatR;

namespace EKadry.Application.Services.Workers.WorkerUpdate
{
    public class WorkerUpdateCommandHandler : ICommandHandler<WorkerUpdateCommand, Unit>
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerUpdateCommandHandler(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public async Task<Unit> Handle(WorkerUpdateCommand request, CancellationToken cancellationToken)
        {
            var worker = await _workerRepository.GetAsync(request.Id);
            worker.Update(
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
            await _workerRepository.UpdateAsync(worker);
            return Unit.Value;
        }
    }
}