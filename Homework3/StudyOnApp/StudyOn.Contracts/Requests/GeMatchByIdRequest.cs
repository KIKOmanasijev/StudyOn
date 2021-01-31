namespace StudyOn.Contracts.Requests
{
    public class GeMatchByIdRequest : IRequest
    {
        /// <summary>
        ///     Id of the Match
        /// </summary>
        public string MatchId { get; set; }
    }
}
