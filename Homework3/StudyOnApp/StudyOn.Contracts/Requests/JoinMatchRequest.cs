namespace StudyOn.Contracts.Requests
{
    public class JoinMatchRequest
    {
        /// <summary>
        ///     The Id of the user and the Id of the match to which the user is joining
        /// </summary>
        public string UserId { get; set; }
        public string MatchId { get; set; }
    }
}
