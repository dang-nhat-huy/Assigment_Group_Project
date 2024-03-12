using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Startu
    {
        public Startu()
        {
            Orders = new HashSet<Order>();
            Users = new HashSet<User>();
        }

        public long StartusId { get; set; }
        public string? StartusName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
