using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Contracts.Requests
{
    public class AddMatchRequest
    {
        public string UserId { get; set; }
        public string CourtId { get; set; }
        public short MaxPlayers { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public short CurrentPlayers { get; set; }
        public string Type { get; set; }
    }
}