using System;
using System.Collections.Generic;

namespace Court.Contracts.Models
{
    public partial class Matches
    {
        public Matches()
        {
            UserMatches = new HashSet<UserMatches>();
        }

        public string Id { get; set; }
        public decimal CourtId { get; set; }
        public short MaxPlayers { get; set; }
        public short CurrentPlayers { get; set; }
        public string Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Courts Court { get; set; }
        public virtual ICollection<UserMatches> UserMatches { get; set; }
    }
}
