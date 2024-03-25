using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace Assignment_Group_Project_RazorPages.Pages.RoomPages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Room Room { get; set; } = default!;
    }
}
