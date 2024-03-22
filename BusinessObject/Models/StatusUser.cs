using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class StatusUser
    {
        public StatusUser()
        {
            Users = new HashSet<User>();
        }

        public long StatusUserId { get; set; }
        [Required]
        [MinLength(1)]
        public string? StatusName { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
