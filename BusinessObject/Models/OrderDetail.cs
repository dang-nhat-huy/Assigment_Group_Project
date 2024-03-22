using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            OrderDetailMenus = new HashSet<OrderDetailMenu>();
            OrderDetailServices = new HashSet<OrderDetailService>();
        }

        public long OrderDetailId { get; set; }
        public string? Note { get; set; }
        public double? Commission { get; set; }
        [Required]
        public long? OrderId { get; set; }
        [Required]
        public long? RoomId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Room? Room { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetailMenu> OrderDetailMenus { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetailService> OrderDetailServices { get; set; }
    }
}
