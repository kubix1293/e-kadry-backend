namespace EKadry.Domain.Pkzp.Parameters
{
    public class PkzpParameters
    {
        public int Form { get; set; }
        public int InstallmentsCount { get; set; }
        public decimal Entry { get; set; }
        public decimal MinComposition { get; set; }
        public decimal MaxComposition { get; set; }
        public decimal MaxAmount { get; set; }
        public decimal MinContribution { get; set; }

        public PkzpParameters()
        {
        }
    }
}