using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Task
    {
        public Task()
        {
            UserTasks = new HashSet<UserTask>();
        }

        public long TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDetail { get; set; }

        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
