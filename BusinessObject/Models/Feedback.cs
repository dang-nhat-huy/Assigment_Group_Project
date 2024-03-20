using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Feedback
    {
        public long FbId { get; set; }
        [Required]
        [MinLength(1)]
        public string? FbContent { get; set; }
        [Required]
        public long? UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
