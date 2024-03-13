using System;
using System.Collections.Generic;

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
        public string? Room { get; set; }
        public string? Comission { get; set; }
        public long? OrderId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual ICollection<OrderDetailMenu> OrderDetailMenus { get; set; }
        public virtual ICollection<OrderDetailService> OrderDetailServices { get; set; }
    }
}
