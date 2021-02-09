using System;

namespace EKadry.API.Http.Pkzp.Request
{
    public class DownloadListPkzpPositionRequest
    {
        public string Types { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}