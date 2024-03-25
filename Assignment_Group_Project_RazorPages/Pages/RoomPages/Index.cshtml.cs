using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace Assignment_Group_Project_RazorPages.Pages.RoomPages
{
    public class IndexModel : PageModel
    {
        public IList<Room> Room { get;set; } = default!;

    }
}
