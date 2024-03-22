using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            UserOrders = new HashSet<UserOrder>();
        }

        public long OrderId { get; set; }
        [Required]
        public double? TotalFees { get; set; }
        [Required]
        [MinLength(1)]
        public string? Address { get; set; }
        [Required]
        public DateTime? StartTime { get; set; }
        [Required]
        public DateTime? EndTime { get; set; }
        [Required]
        public long? VoucherId { get; set; }
        [Required]
        public long? StatusId { get; set; }

        public virtual Status? Status { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserOrder> UserOrders { get; set; }
    }
}
