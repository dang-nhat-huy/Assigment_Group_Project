using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderDetailService
    {
        public long OrderDetailServiceId { get; set; }
        public long? ServiceId { get; set; }
        public long? OrderDetailId { get; set; }

        public virtual OrderDetail? OrderDetail { get; set; }
        public virtual Service? Service { get; set; }
    }
}
