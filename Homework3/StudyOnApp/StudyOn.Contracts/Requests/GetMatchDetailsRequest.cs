namespace StudyOn.Contracts.Requests
{
    public class GetMatchDetailsRequest : IRequest
    {
        public string MatchId { get; set; }
    }
}
