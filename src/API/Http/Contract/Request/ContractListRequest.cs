using System;

namespace EKadry.API.Http.Contract.Request
{
    public class ContractListRequest : ListRequest
    {
        public bool? ShowInactiveContracts { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}