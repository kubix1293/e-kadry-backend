namespace EKadry.Domain
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}