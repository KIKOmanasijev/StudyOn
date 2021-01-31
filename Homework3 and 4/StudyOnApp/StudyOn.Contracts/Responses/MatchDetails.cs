using System;

namespace StudyOn.Contracts.Responses
{
    public class MatchDetails
    {
        /// <summary>
        ///     Contains all the parametars returned for match details
        /// </summary>
        public string MatchId { get; set; }
        public string CourtName { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public short MaxPlayers { get; set; }
        public short CurrentPlayers { get; set; }
        public string Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
