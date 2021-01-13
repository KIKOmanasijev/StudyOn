namespace Court.Contracts.Requests
{
    public class GetCourtsRequest : SortablePageableRequest
    {
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
