namespace StudyOn.Contracts.Requests
{
    public class AddUserRequest : IRequest
    {
        /// <summary>
        ///     Contains all the parametars needed for creating a new user
        /// </summary>
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
