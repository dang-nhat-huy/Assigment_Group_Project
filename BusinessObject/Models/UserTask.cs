using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class UserTask
    {
        public long UserTaskId { get; set; }
        public long? TaskId { get; set; }
        public long? UserId { get; set; }

        public virtual Task? Task { get; set; }
        public virtual User? User { get; set; }
    }
}
