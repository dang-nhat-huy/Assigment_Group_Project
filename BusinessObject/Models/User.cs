using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Feedbacks = new HashSet<Feedback>();
            UserOrders = new HashSet<UserOrder>();
            UserTasks = new HashSet<UserTask>();
        }

        public long UserId { get; set; }
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
        public DateTime? DoB { get; set; }
        public string? Role { get; set; }
        public long? StatusId { get; set; }

        public virtual Status? Status { get; set; }
        [JsonIgnore]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<UserOrder> UserOrders { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
