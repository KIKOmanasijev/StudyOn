using System;
using System.Collections.Generic;

namespace StudyOn.Data
{
    public partial class Courts
    {
        public Courts()
        {
            Images = new HashSet<Images>();
            Matches = new HashSet<Matches>();
            Ratings = new HashSet<Ratings>();
        }

        public decimal Id { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public string Sport { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Images> Images { get; set; }
        public virtual ICollection<Matches> Matches { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }
    }
}
