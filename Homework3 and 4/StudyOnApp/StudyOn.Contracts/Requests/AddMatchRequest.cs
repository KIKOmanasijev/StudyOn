using System;

namespace StudyOn.Contracts.Requests
{
    public class AddMatchRequest
    {
        /// <summary>
        ///     Contains all the parametars needed for creating a new match
        /// </summary>
        public string UserId { get; set; }
        public string CourtId { get; set; }
        public short MaxPlayers { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public short CurrentPlayers { get; set; }
        public string Type { get; set; }
    }
}