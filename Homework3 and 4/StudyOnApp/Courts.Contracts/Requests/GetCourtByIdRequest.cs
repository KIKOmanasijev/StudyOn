namespace Court.Contracts.Requests
{
    public class GetCourtByIdRequest : IRequest
    {        /// <summary>
             ///     Id of the Court
             /// </summary>
        public decimal CourtId { get; set; }
    }
}
