using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;

namespace Assignment_Group_Project_RazorPages.Pages.MenuPages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Menu Menu { get; set; } = default!;
    }
}
