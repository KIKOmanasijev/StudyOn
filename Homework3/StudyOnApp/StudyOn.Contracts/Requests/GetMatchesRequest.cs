namespace StudyOn.Contracts.Requests
{
    public class GetMatchesRequest : SortablePageableRequest
    {
        public string Type { get; set; }
    }
}
