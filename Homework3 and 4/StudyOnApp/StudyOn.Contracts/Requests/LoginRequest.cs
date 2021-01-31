namespace StudyOn.Contracts.Requests
{
    public class LoginRequest : IRequest
    {
        /// <summary>
        ///     Contains all the parametars needed for user sign in
        /// </summary>
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
