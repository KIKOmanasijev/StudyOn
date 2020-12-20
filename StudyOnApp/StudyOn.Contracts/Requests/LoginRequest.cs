namespace StudyOn.Contracts.Requests
{
    public class LoginRequest : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
