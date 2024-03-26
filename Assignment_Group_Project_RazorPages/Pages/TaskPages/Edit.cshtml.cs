using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Task = BusinessObject.Models.Task;

namespace Assignment_Group_Project_RazorPages.Pages.TaskPages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Task Task { get; set; } = default!;
    }
}
