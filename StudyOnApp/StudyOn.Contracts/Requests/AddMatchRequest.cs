using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Contracts.Requests
{
    public class AddMatchRequest
    {
        public decimal CourtId { get; set; }
        public short MaxPlayers { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public short CurrentPlayers { get; set; }
        public string Type { get; set; }
    }
}
