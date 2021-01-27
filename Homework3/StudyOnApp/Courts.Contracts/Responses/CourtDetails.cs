using Court.Contracts.Models;
using System.Collections.Generic;

namespace Court.Contracts.Responses
{
    public class CourtDetails
    {
        public decimal Id { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public string Sport { get; set; }
        public string Name { get; set; }

        public List<UserRatings> userRatings = new List<UserRatings>();
        public float AverageRating { get; set; }
    }
}
