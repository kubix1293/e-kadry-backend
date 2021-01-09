using System;
using EKadry.Application.Configuration.Commands;
using MediatR;

namespace EKadry.Application.Services.Workers.WorkerUpdate
{
    public class WorkerUpdateCommand : CommandBase<Unit>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string CityOfBirthday { get; set; }
        public string Pesel { get; set; }
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public int Gender { get; set; }
        public string Street { get; set; }
        public string PropertyNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ActNumber { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string Phone { get; set; }

        public WorkerUpdateCommand(
            Guid id,
            string firstName,
            string lastName,
            string birthday,
            string cityOfBirthday,
            string pesel,
            int documentType,
            string documentNumber,
            int gender,
            string street,
            string propertyNumber,
            string apartmentNumber,
            string zipCode,
            string city,
            string country,
            string actNumber,
            string motherName,
            string fatherName,
            string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            CityOfBirthday = cityOfBirthday;
            Pesel = pesel;
            DocumentType = documentType;
            DocumentNumber = documentNumber;
            Gender = gender;
            Street = street;
            PropertyNumber = propertyNumber;
            ApartmentNumber = apartmentNumber;
            ZipCode = zipCode;
            City = city;
            Country = country;
            ActNumber = actNumber;
            MotherName = motherName;
            FatherName = fatherName;
            Phone = phone;
        }
    }
}