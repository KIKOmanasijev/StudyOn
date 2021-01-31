namespace Court.Contracts.Requests
{
    public class GetCourtsRequest : SortablePageableRequest
    {
        /// <summary>
        ///     The type of sport that the search is based on and the Name of the court
        /// </summary>
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
