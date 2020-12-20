﻿using System;
using System.Collections.Generic;

namespace StudyOn.Contracts.Models
{
    public partial class Ratings
    {
        public string UserId { get; set; }
        public decimal CourtId { get; set; }
        public short Rate { get; set; }
        public string Comment { get; set; }
        public string Id { get; set; }

        public virtual Courts Court { get; set; }
        public virtual Users User { get; set; }
    }
}
