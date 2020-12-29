namespace EKadry.API.Http.Operator.Request
{
    public class UpdateOperatorRequest
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
    }
}