using System.ComponentModel.DataAnnotations;

namespace EKadry.Domain.Workers
{
    public enum Gender
    {
        [Display(Name = "Mężczyna")]
        Male = 10,
        [Display(Name = "Kobieta")]
        Female = 20,
        [Display(Name = "Nie podano")]
        NotGiven = 999,
    }
}