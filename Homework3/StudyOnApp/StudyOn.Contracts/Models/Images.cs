using System;
using System.Collections.Generic;

namespace StudyOn.Contracts.Models
{
    public partial class Images
    {
        public string Id { get; set; }
        public decimal CourtId { get; set; }
        public string Path { get; set; }

        public virtual Courts Court { get; set; }
    }
}
