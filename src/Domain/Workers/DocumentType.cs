using System.ComponentModel.DataAnnotations;

namespace EKadry.Domain.Workers
{
    public enum DocumentType 
    {
        [Display(Name = "Dokument tożsamości")]
        Id = 10,
        [Display(Name = "Paszport")]
        Passport = 20,
        [Display(Name = "Prawo jazdy")]
        DrivingLicense = 30,
    }
}