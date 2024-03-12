using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Service
    {
        public Service()
        {
            OrderServices = new HashSet<OrderService>();
        }

        public long ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public double? Fee { get; set; }

        public virtual ICollection<OrderService> OrderServices { get; set; }
    }
}
