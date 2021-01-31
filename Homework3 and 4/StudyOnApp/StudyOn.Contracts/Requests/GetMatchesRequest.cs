namespace StudyOn.Contracts.Requests
{
    public class GetMatchesRequest : SortablePageableRequest
    {
        /// <summary>
        ///     The type of sport that the search is baset on
        /// </summary>
        public string Type { get; set; }
    }
}
