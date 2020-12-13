using System;
using System.Collections.Generic;

namespace StudyOn.Data.Models
{
    public partial class Images
    {
        public decimal Id { get; set; }
        public decimal CourtId { get; set; }
        public string ImagePath { get; set; }

        public virtual Courts Court { get; set; }
    }
}
