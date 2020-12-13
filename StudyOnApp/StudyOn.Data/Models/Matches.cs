using System;
using System.Collections.Generic;

namespace StudyOn.Data.Models
{
    public partial class Matches
    {
        public decimal Id { get; set; }
        public decimal CourtId { get; set; }
        public decimal UserId { get; set; }
        public decimal MaxPlayers { get; set; }
        public decimal? CurrentPlayers { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        public virtual Courts Court { get; set; }
        public virtual Users User { get; set; }
    }
}
