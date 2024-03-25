using System.ComponentModel.DataAnnotations;

namespace Assignment_Group_Project_RazorPages.ViewModel
{
    public class LoginUserViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(1)]
        public string? Password { get; set; }
    }
    public class SignUpUserViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(1)]
        public string? Password { get; set; }
        [Required]
        [MinLength(1)]
        public string? ConfirmPassword { get; set; }
    }
}
