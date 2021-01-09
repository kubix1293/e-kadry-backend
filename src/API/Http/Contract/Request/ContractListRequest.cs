namespace EKadry.API.Http.Contract.Request
{
    public class ContractListRequest : ListRequest
    {
        public bool? ShowInactiveContracts { get; set; }
    }
}