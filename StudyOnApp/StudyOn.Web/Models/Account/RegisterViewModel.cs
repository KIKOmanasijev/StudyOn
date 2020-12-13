using System.ComponentModel.DataAnnotations;

namespace StudyOn.Web.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is required")]

        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid email format. Please use someone@example.com as a valid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Only alphabetical input allowed.")]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Only alphabetical input allowed.")]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter,one number and one special character")]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
