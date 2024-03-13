using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderDetailMenu
    {
        public long OrderDetailMenuId { get; set; }
        public long MenuId { get; set; }
        public long OrderDetailId { get; set; }

        public virtual Menu Menu { get; set; } = null!;
        public virtual OrderDetail OrderDetail { get; set; } = null!;
    }
}
