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
    public class TaskRequestVM
    {
        [Required]
        public string? TaskName { get; set; }
        [Required]
        public string? TaskDetail { get; set; }
    }
    public class OrderRequestVM
    {
        [Required]
        public double? TotalFees { get; set; }

        [Required]
        [MinLength(1), MaxLength(255)]
        public string? address { get; set; }

        [Required]
        public DateTime? StartTime { get; set; }
        [Required]
        public DateTime? EndTime { get; set; }
        public long? VoucherId { get; set; }

    }
    public class OrderDetailRequestVM
    {
        public string? Note { get; set; }
        [Required]
        public long? OrderId { get; set; }
        [Required]
        public long? RoomId { get; set; }
    }
    public class OrderDetailUpdateRequestVM
    {
        public string? Note { get; set; }
        [Required]
        public long? RoomId { get; set; }
    }
    public class FeedbackRequestVM
    {
        [Required]
        [MinLength(1)]
        public string? FbContent { get; set; }
        [Required]
        public long? UserId { get; set; }
    }

    public class ServiceRequestVM
    {
        [Required]
        [MinLength(1), MaxLength(50)]
        public string? ServiceName { get; set; }
        [Range(1000, 100000000)]
        public double? Fee { get; set; }
    }
    public class RoomRequestVM
    {
        [Required]
        [MinLength(1)]
        public string? RoomName { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public double? Price { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int? Capacity { get; set; }
    }
    public class UserUpdateByCustomerVM
    {
        [MinLength(1)]
        public string? Fullname { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(1)]
        public string? Password { get; set; }
        [MinLength(8), MaxLength(20)]
        public string? Phone { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid Date of Birth")]
        public DateTime? DoB { get; set; }
    }
    public class VoucherViewModel
    {
        public string? Note { get; set; }
        [Required]
        [MinLength(5), MaxLength(16)]
        public string? Code { get; set; }
        [Required]
        public int ExpireDay { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int ExpireHour { get; set; }
        public int ExpireMinute { get; set; }
        [Required]
        [Range(0.05, 1.0)]
        public double? Discount { get; set; }
    }
}
