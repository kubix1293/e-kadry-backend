using System;
using System.Collections.Generic;
using EKadry.Domain.Contracts;
using EKadry.Domain.Pkzp.Contributions;
using EKadry.Domain.Pkzp.Position;

namespace EKadry.Domain.Workers
{
    public class Worker : BaseEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
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
        public Guid? OperatorId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual IEnumerable<Contract> Contracts { get; set; }
        public virtual IEnumerable<Pkzp.Pkzp> Pkzp { get; set; }
        public virtual IEnumerable<PkzpPosition> PkzpPositions { get; set; }
        public virtual IEnumerable<PkzpContribution> PkzpContributions { get; set; }

        public Worker()
        {
        }

        public static Worker Create(
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
            string phone
            )
        {
            return new Worker()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Birthday = DateTime.Parse(birthday),
                CityOfBirthday = cityOfBirthday,
                Pesel = pesel,
                DocumentType = EnumHelper<DocumentType>.Parse(documentType.ToString()),
                DocumentNumber = documentNumber,
                Gender = EnumHelper<Gender>.Parse(gender.ToString()),
                Street = street,
                PropertyNumber = propertyNumber,
                ApartmentNumber = apartmentNumber,
                ZipCode = zipCode,
                City = city,
                Country = country,
                ActNumber = actNumber,
                MotherName = motherName,
                FatherName = fatherName,
                Phone = phone,
            };
        }
        
        public void Update(
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
            string phone
        )
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = DateTime.Parse(birthday);
            CityOfBirthday = cityOfBirthday;
            Pesel = pesel;
            DocumentType = EnumHelper<DocumentType>.Parse(documentType.ToString());
            DocumentNumber = documentNumber;
            Gender = EnumHelper<Gender>.Parse(gender.ToString());
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