using System;
using System.Collections.Generic;
using EKadry.Domain.Contracts;
using EKadry.Domain.Operators;

namespace EKadry.Domain.Workers
{
    public class Worker : Entity, IAggregateRoot
    {
        public WorkerId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string CityOfBirthday { get; set; }
        public string Pesel { get; set; }
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public Gender Gender { get; set; }
        public string IdCity { get; set; }
        public string Street { get; set; }
        public string PropertyNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string ActNumber { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string Phone { get; set; }
        public OperatorId OperatorId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public ICollection<Contract> Contracts { get; set; }

        public Worker()
        {
        }

        public static Worker CreateWorker(
            string firstName,
            string lastName,
            string birthday,
            string cityOfBirthday,
            string pesel,
            int documentType,
            string documentNumber,
            int gender,
            string idCity,
            string street,
            string propertyNumber,
            string apartmentNumber,
            string actNumber,
            string motherName,
            string fatherName,
            string phone
            )
        {
            return new Worker()
            {
                Id = new WorkerId(Guid.NewGuid()),
                FirstName = firstName,
                LastName = lastName,
                Birthday = DateTime.Parse(birthday),
                CityOfBirthday = cityOfBirthday,
                Pesel = pesel,
                DocumentType = EnumHelper<DocumentType>.Parse(documentType.ToString()),
                DocumentNumber = documentNumber,
                Gender = EnumHelper<Gender>.Parse(gender.ToString()),
                IdCity = idCity,
                Street = street,
                PropertyNumber = propertyNumber,
                ApartmentNumber = apartmentNumber,
                ActNumber = actNumber,
                MotherName = motherName,
                FatherName = fatherName,
                Phone = phone,
            };
        }
    }
}