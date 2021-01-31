namespace Court.Contracts.Requests
{
    public class ReviewCourtRequest
    {
        /// <summary>
        ///     The Id of the user and the Id of the court for which the Rate and Comment apply
        /// </summary>
        public decimal CourtId { get; set; }
        public string UserId { get; set; }
        public short Rate { get; set; }
        public string Comment { get; set; }
    }
}
