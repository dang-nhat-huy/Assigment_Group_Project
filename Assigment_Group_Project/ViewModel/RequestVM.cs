using BusinessObject.Models;
using System.ComponentModel.DataAnnotations;

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
        public DateTime? StartTime { get; set; }
        [Required]
        public DateTime? EndTime { get; set; }
        public long? VoucherId { get; set; }
        [Required]
        public long? UserId { get; set; }
    }
}
