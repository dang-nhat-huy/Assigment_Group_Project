using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace Assignment_Group_Project_RazorPages.Pages.Feedbackpages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Feedback Feedback { get; set; } = default!;
    }
}
