using System.ComponentModel.DataAnnotations;

namespace EKadry.Domain.Pkzp.Position
{
    public enum PkzpPositionType 
    {
        [Display(Name = "Wkład piniężny")]
        Contribution = 10,
        [Display(Name = "Pożyczka pieniężna")]
        Loan = 20,
        [Display(Name = "Wpisowe")]
        EntryFee = 30,
        [Display(Name = "Spłata")]
        Repayment = 40,
    }
}