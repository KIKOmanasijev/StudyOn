using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Contracts.Models
{
    public class UserRegister
    {
        public decimal Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
