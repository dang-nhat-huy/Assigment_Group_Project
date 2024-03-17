using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Menu
    {
        public Menu()
        {
            OrderDetailMenus = new HashSet<OrderDetailMenu>();
        }

        public long MenuId { get; set; }
        [Required]
        [MinLength(1), MaxLength(50)]
        public string? MenuItem { get; set; }
        public double? Price { get; set; }
        public long? CategoriesId { get; set; }

        public virtual Category? Categories { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetailMenu> OrderDetailMenus { get; set; }
    }
}
