using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Service
    {
        public Service()
        {
            OrderDetailServices = new HashSet<OrderDetailService>();
        }

        public long ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public double? Fee { get; set; }

        public virtual ICollection<OrderDetailService> OrderDetailServices { get; set; }
    }
}
