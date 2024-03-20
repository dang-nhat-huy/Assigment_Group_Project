using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Category
    {
        public Category()
        {
            Menus = new HashSet<Menu>();
        }

        public long CategoriesId { get; set; }
        [Required]
        [MinLength(1), MaxLength(50)]
        public string? CategoriesName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
