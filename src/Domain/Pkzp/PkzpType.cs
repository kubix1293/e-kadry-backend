using System.ComponentModel.DataAnnotations;

namespace EKadry.Domain.Pkzp
{
    public enum PkzpType 
    {
        [Display(Name = "Wkład pieniężny")]
        Contribution = 10,
        [Display(Name = "Pożyczka pieniężna")]
        Loan = 20,
    }
}