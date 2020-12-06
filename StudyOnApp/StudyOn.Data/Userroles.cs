using System;
using System.Collections.Generic;

namespace StudyOn.Data
{
    public partial class Userroles
    {
        public decimal RoleId { get; set; }
        public decimal UserId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
