﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            Orders = new HashSet<Order>();
        }

        public long VoucherId { get; set; }
        public string? Note { get; set; }
        public string? Code { get; set; }
        public DateTime? ExpireDate { get; set; }
        public double? Discount { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
