using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Assignment_Group_Project_RazorPages.Pages.UserPages
{
    public class DeleteModel : PageModel
    {

        [BindProperty]
        public User BanUser { get; set; } = default!;
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
                BanUser = JsonConvert.DeserializeObject<User>(responseBody)!;
            }
            else
            {
                string msg = await response.Content.ReadAsStringAsync();
                TempData["error"] = msg;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                string? jwt = Request.Cookies["jwt"]!.ToString();
                var id = BanUser.UserId;
                var role = BanUser.Role;
                string url = $"http://localhost:5201/User/ChangeStatus/{id}";
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
