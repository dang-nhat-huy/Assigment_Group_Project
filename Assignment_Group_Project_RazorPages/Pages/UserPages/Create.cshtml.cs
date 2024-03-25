using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;

namespace Assignment_Group_Project_RazorPages.Pages.UserPages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public User NewUser { get; set; } = default!;
    }
}
