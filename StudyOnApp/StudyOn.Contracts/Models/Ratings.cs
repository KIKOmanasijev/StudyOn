using System;
using System.Collections.Generic;

namespace StudyOn.Contracts.Models
{
    public partial class Ratings
    {
        public decimal Id { get; set; }
        public decimal Value { get; set; }
        public string Comment { get; set; }
        public decimal UserId { get; set; }
        public decimal CourtId { get; set; }

        public virtual Courts Court { get; set; }
        public virtual Users User { get; set; }
    }
}
