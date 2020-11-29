using System;
using EKadry.Domain.Workers;

namespace EKadry.Application.Services.Workers.WorkerList
{
    public class WorkerListDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DocumentType DoumnetType { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}