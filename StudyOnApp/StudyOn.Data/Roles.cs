using System;
using System.Collections.Generic;

namespace StudyOn.Data
{
    public partial class Roles
    {
        public Roles()
        {
            Userroles = new HashSet<Userroles>();
        }

        public decimal Id { get; set; }
        public string[] RoleName { get; set; }

        public virtual ICollection<Userroles> Userroles { get; set; }
    }
}
