using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderService
    {
        public long OrderServiceId { get; set; }
        public long? ServiceId { get; set; }
        public long? OrderId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Service? Service { get; set; }
    }
}
