using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class StatusRoom
    {
        public StatusRoom()
        {
            Rooms = new HashSet<Room>();
        }

        public long StatusRoomId { get; set; }
        [Required]
        [MinLength(1)]
        public string? StatusName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
