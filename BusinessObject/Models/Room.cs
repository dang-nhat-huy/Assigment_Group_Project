using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Room
    {
        public Room()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long RoomId { get; set; }
        public string? RoomName { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public double? Price { get; set; }
        public int? Capacity { get; set; }
        public long? StatusRoomId { get; set; }

        public virtual StatusRoom? StatusRoom { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
