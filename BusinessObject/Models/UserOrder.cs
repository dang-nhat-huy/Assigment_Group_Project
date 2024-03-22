using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class UserOrder
    {
        public long UserOrderId { get; set; }
        public long? UserId { get; set; }
        public long? OrderId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual User? User { get; set; }
    }
}
