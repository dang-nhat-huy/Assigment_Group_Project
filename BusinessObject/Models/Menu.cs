using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Menu
    {
        public long MenuId { get; set; }
        public string? MenuItem { get; set; }
        public double? Price { get; set; }
        public long? OrderId { get; set; }
        public long? CategoriesId { get; set; }

        public virtual Category? Categories { get; set; }
        public virtual Order? Order { get; set; }
    }
}
