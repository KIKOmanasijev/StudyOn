using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Contracts.Requests
{
    public class JoinMatchRequest
    {
        public string userId { get; set; }
        public string matchId { get; set; }
    }
}
