namespace Court.Contracts.Requests
{
    public class GetCourtByIdRequest : IRequest
    {
        public decimal CourtId { get; set; }
    }
}
