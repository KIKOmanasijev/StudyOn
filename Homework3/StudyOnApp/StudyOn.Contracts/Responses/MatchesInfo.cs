using System;

namespace StudyOn.Contracts.Responses
{
    public class MatchesInfo
    {
        public short MaxPlayers { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public short RemainingPlaces { get; set; }
        public string Type { get; set; }
    }
}
