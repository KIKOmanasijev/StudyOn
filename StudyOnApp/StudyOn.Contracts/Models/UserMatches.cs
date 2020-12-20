using System;
using System.Collections.Generic;

namespace StudyOn.Contracts.Models
{
    public partial class UserMatches
    {
        public string UserId { get; set; }
        public string MatchId { get; set; }

        public virtual Matches Match { get; set; }
        public virtual Users User { get; set; }
    }
}
