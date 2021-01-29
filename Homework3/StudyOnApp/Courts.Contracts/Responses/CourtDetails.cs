namespace Court.Contracts.Responses
{
    public class CourtDetails
    {
        public decimal Id { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public string Sport { get; set; }
        public string Name { get; set; }
        public float AverageRating { get; set; }
    }
}
