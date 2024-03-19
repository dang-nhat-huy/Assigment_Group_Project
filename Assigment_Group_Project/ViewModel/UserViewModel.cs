using System.ComponentModel.DataAnnotations;

namespace Assigment_Group_Project.ViewModel
{
    public class SignUpUserVM
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(8)]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
    }
    public class UserCreateByAdminVM
    {
        [MinLength(1)]
        public string? Fullname { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(8)]
        public string? Password { get; set; }
        [MinLength(8), MaxLength(20)]
        public string? Phone { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid Date of Birth")]
        public DateTime? DoB { get; set; }
        [Required]
        public string? Role { get; set; }
    }
    public class UserUpdateByCustomerVM
    {
        [MinLength(1)]
        public string? Fullname { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(8)]
        public string? Password { get; set; }
        [MinLength(8), MaxLength(20)]
        public string? Phone { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid Date of Birth")]
        public DateTime? DoB { get; set; }
    }
}
