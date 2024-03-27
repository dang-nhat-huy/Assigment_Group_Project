using BusinessObject.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assigment_Group_Project.ViewModel
{
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

    public class UserTaskRequestVM
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long? TaskId { get; set; }
        [Required]
        [Range(1, long.MaxValue)]
        public long? UserId { get; set; }
    }

    public class UserOrderRequestVM
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long? OrderId { get; set; }
        [Required]
        [Range(1, long.MaxValue)]
        public long? UserId { get; set; }
    }
}
