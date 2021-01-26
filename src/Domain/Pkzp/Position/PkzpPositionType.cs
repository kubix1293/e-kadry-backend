using System.ComponentModel.DataAnnotations;

namespace EKadry.Domain.Pkzp.Position
{
    public enum PkzpPositionType 
    {
        [Display(Name = "Wpisowe")]
        EntryFee = 30,
        [Display(Name = "Saldo początkowe")]
        InitBalance = 10,
        [Display(Name = "Pożyczka pieniężna")]
        Loan = 20,
        [Display(Name = "Spłata")]
        Repayment = 40,
    }
}