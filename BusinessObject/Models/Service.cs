using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Service
    {
        public Service()
        {
            OrderDetailServices = new HashSet<OrderDetailService>();
        }

        public long ServiceId { get; set; }
        [Required]
        [MinLength(1), MaxLength(50)]
        public string? ServiceName { get; set; }
        [Range(1000, 100000000)]
        public double? Fee { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetailService> OrderDetailServices { get; set; }
    }
}
