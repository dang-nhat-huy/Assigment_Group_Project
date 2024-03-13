using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Menu
    {
        public Menu()
        {
            OrderDetailMenus = new HashSet<OrderDetailMenu>();
        }

        public long MenuId { get; set; }
        public string? MenuItem { get; set; }
        public double? Price { get; set; }
        public long? CategoriesId { get; set; }

        public virtual Category? Categories { get; set; }
        public virtual ICollection<OrderDetailMenu> OrderDetailMenus { get; set; }
    }
}
