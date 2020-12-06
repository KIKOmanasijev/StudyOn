using System;
using System.Collections.Generic;

namespace StudyOn.Data
{
    public partial class Ratings
    {
        public decimal Id { get; set; }
        public decimal Value { get; set; }
        public decimal CourtId { get; set; }
        public decimal UserId { get; set; }
        public string[] Comment { get; set; }

        public virtual Courts Court { get; set; }
        public virtual Users User { get; set; }
    }
}
