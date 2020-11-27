namespace EKadry.API.Http
{
    public class ListRequest
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public string OrderDirection { get; set; }
        public string OrderBy { get; set; }
        public string Search { get; set; }
    }
}