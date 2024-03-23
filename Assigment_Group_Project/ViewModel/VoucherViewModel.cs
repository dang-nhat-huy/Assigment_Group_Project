using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;

namespace Assigment_Group_Project.ViewModel
{
    public class VoucherViewModel
    {
        public string? Note { get; set; }
        [Required]
        [MinLength(5), MaxLength(16)]
        public string? Code { get; set; }
        [Required]
        public int ExpireDay { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int ExpireHour { get; set; }
        public int ExpireMinute { get; set; }
        [Required]
        [Range(0.05, 1.0)]
        public double? Discount { get; set; }
    }
}
