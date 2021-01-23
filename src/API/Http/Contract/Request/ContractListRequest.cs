using System;

namespace EKadry.API.Http.Contract.Request
{
    public class ContractListRequest : ListRequest
    {
        public Guid? JobPosition { get; set; }
        public bool? ShowInactiveContracts { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool? HasPkzp { get; set; }
    }
}