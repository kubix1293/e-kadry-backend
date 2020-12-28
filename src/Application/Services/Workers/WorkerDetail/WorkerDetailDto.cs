using System;
using System.Collections.Generic;
using EKadry.Application.Services.Contracts;
using EKadry.Domain.Contracts;
using EKadry.Domain.Operators;

namespace EKadry.Application.Services.Workers.WorkerDetail
{
    public class WorkerDetailDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string CityOfBirthday { get; set; }
        public string Pesel { get; set; }
        public EnumApi DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public EnumApi Gender { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PropertyNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string ActNumber { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string Phone { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}