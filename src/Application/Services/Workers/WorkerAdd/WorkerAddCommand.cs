using EKadry.Application.Configuration.Commands;
using EKadry.Domain;
using EKadry.Domain.Workers;

namespace EKadry.Application.Services.Workers.WorkerAdd
{
    public class WorkerAddCommand : CommandBase<WorkerDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string CityOfBirthday { get; set; }
        public string Pesel { get; set; }
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public Gender Gender { get; set; }
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

        public WorkerAddCommand(
            string firstName,
            string lastName,
            string birthday,
            string cityOfBirthday,
            string pesel,
            DocumentType documentType,
            string documentNumber,
            Gender gender,
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