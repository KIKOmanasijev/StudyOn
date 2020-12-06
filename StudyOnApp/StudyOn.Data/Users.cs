using System;
using System.Collections.Generic;

namespace StudyOn.Data
{
    public partial class Users
    {
        public Users()
        {
            Matches = new HashSet<Matches>();
            Ratings = new HashSet<Ratings>();
            Userroles = new HashSet<Userroles>();
        }

        public decimal Id { get; set; }
        public string[] FirstName { get; set; }
        public string[] LastName { get; set; }
        public string[] Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Matches> Matches { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }
        public virtual ICollection<Userroles> Userroles { get; set; }
    }
}
