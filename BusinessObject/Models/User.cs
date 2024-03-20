using System;
using System.Collections.Generic;

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
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public DateTime? DoB { get; set; }
        public string? Role { get; set; }
        public long? StatusId { get; set; }

        public virtual Status? Status { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<UserOrder> UserOrders { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
