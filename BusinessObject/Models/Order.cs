using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Order
    {
        public Order()
        {
            Menus = new HashSet<Menu>();
            OrderServices = new HashSet<OrderService>();
        }

        public long OrderId { get; set; }
        public string? Note { get; set; }
        public string? Room { get; set; }
        public string? Comission { get; set; }
        public double? TotalFees { get; set; }
        public string? Status { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public long? VoucherId { get; set; }
        public long? UserId { get; set; }
        public long? StatusId { get; set; }

        public virtual Status? StatusNavigation { get; set; }
        public virtual User? User { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<OrderService> OrderServices { get; set; }
    }
}
