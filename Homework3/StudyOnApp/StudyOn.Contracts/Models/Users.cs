using System;
using System.Collections.Generic;

namespace StudyOn.Contracts.Models
{
    public partial class Users
    {
        public Users()
        {
            Ratings = new HashSet<Ratings>();
            UserMatches = new HashSet<UserMatches>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public virtual ICollection<Ratings> Ratings { get; set; }
        public virtual ICollection<UserMatches> UserMatches { get; set; }
    }
}
