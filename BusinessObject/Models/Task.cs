using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Task
    {
        public Task()
        {
            UserTasks = new HashSet<UserTask>();
        }

        public long TaskId { get; set; }
        [Required]
        public string? TaskName { get; set; }
        public string? TaskDetail { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
