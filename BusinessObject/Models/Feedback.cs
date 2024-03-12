using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Feedback
    {
        public long FbId { get; set; }
        public string? FbContent { get; set; }
        public long? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
