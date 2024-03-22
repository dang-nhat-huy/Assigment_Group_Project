using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class StatusOrder
    {
        public StatusOrder()
        {
            Orders = new HashSet<Order>();
        }

        public long StatusOrderId { get; set; }
        [Required]
        [MinLength(1)]
        public string? StatusName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
