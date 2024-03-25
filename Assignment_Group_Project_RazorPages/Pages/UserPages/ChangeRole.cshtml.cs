using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Newtonsoft.Json;

namespace Assignment_Group_Project_RazorPages.Pages.UserPages
{
    public class ChangeRoleModel : PageModel
    {
        [BindProperty]
        public User EditUser { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(long id)
        {

            var role = HttpContext.Session.GetString("role");
            string? jwt = Request.Cookies["jwt"];
            if (role == null || jwt == null)
            {
                TempData["error"] = "You need to login to access this page";
                return RedirectToPage("../Logout");
            }
            if (!role.Equals("Manager"))
            {
                TempData["error"] = "You don't have access to this page";
                return RedirectToPage("../Logout");
            }

            jwt = jwt.ToString();
            string url = $"http://localhost:5201/User/Get/{id}";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
            HttpRequestMessage request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                EditUser = JsonConvert.DeserializeObject<User>(responseBody)!;
            }
            else
            {
                string msg = await response.Content.ReadAsStringAsync();
                TempData["error"] = msg;
            }

            ViewData["Roles"] = new SelectList(new[]
            {
                    new { Value = "Manager", Text = "Manager" },
                    new { Value = "Staff", Text = "Staff" },
                    new { Value = "Customer", Text = "Customer" },
            }, "Value", "Text");

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                
                string? jwt = Request.Cookies["jwt"]!.ToString();
                var id = EditUser.UserId;
                var role = EditUser.Role;
                string url = $"http://localhost:5201/User/UpdateRoleByManager/{id}?role={role}";
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Patch
                };
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string msg = await response.Content.ReadAsStringAsync();
                    TempData["success"] = msg;
                    return RedirectToPage("./Index");
                }
                else
                {
                    string msg = await response.Content.ReadAsStringAsync();
                    TempData["error"] = msg;
                }
                return Page();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return Page();
            }
        }
    }
}
