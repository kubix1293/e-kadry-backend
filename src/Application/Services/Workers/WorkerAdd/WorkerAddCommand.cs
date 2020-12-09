using EKadry.Application.Configuration.Commands;

namespace EKadry.Application.Services.Workers.WorkerAdd
{
    public class WorkerAddCommand : CommandBase<WorkerDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string CityOfBirthday { get; set; }
        public string Pesel { get; set; }
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public int Gender { get; set; }
        public string IdCity { get; set; }
        public string Street { get; set; }
        public string PropertyNumber { get; set; }
        public string ApartmentNumber { get; set; }
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
            IdCity = idCity;
            Street = street;
            PropertyNumber = propertyNumber;
            ApartmentNumber = apartmentNumber;
            ActNumber = actNumber;
            MotherName = motherName;
            FatherName = fatherName;
            Phone = phone;
        }
    }
}