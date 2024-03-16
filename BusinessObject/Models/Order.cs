using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long OrderId { get; set; }
        [Required]
        public double? TotalFees { get; set; }
        [Required]
        public DateTime? StartTime { get; set; }
        [Required]
        public DateTime? EndTime { get; set; }
        public long? VoucherId { get; set; }
        [Required]
        public long? UserId { get; set; }
        [Required]
        public long? StatusId { get; set; }

        public virtual Status? Status { get; set; }
        public virtual User? User { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
