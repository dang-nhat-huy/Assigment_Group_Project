using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Room
    {
        public Room()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long RoomId { get; set; }
        [Required]
        [MinLength(1)]
        public string? RoomName { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public double? Price { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int? Capacity { get; set; }
        [Required]
        public long? StatusRoomId { get; set; }

        public virtual StatusRoom? StatusRoom { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
