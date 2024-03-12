using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Category
    {
        public Category()
        {
            Menus = new HashSet<Menu>();
        }

        public long CategoriesId { get; set; }
        public string? CategoriesName { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
