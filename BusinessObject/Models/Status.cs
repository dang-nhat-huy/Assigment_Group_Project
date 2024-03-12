using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
            Users = new HashSet<User>();
        }

        public long StatusId { get; set; }
        public string? StatusName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
