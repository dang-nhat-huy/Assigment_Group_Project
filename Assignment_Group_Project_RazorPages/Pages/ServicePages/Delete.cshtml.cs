﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace Assignment_Group_Project_RazorPages.Pages.ServicePages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Service Service { get; set; } = default!;
    }
}
