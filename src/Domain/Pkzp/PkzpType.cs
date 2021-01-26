using System.ComponentModel.DataAnnotations;

namespace EKadry.Domain.Pkzp
{
    public enum PkzpType 
    {
        [Display(Name = "Saldo początkowe")]
        InitBalance = 10,
        [Display(Name = "Pożyczka pieniężna")]
        Loan = 20,
    }
}