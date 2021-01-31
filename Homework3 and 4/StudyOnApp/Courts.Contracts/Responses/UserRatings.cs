namespace Court.Contracts.Responses
{
    public class UserRatings
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }
    }
}
