namespace StudyOn.Contracts.Responses
{
    public class UserInfo
    {
        /// <summary>
        ///     Contains all the information for the user we return
        /// </summary>
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
