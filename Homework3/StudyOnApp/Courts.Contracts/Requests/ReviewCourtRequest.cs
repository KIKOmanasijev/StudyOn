namespace Court.Contracts.Requests
{
    public class ReviewCourtRequest
    {
        public decimal CourtId { get; set; }
        public string UserId { get; set; }
        public short Rate { get; set; }
        public string Comment { get; set; }
    }
}
