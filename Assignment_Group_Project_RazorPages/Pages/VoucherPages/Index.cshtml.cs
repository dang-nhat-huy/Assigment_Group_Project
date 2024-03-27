using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Newtonsoft.Json;

namespace Assignment_Group_Project_RazorPages.Pages.VoucherPages
{
    public class IndexModel : PageModel
    {
        public IList<Voucher> Voucher { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public int Index { get; set; } = 1;
        public double Count { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            try
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
                var quantity = 10;
                string url = $"http://localhost:5201/Voucher/GetAll?page={Index}&quantity={quantity}";
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
                    Voucher = JsonConvert.DeserializeObject<IList<Voucher>>(responseBody)!;
                }
                else
                {
                    string msg = await response.Content.ReadAsStringAsync();
                    TempData["error"] = msg;
                }

                Count = await CountMaxPage();

                return Page();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return Page();
            }
        }
        private async Task<double> CountMaxPage()
        {
            try
            {
                double count = 1;
                IList<User> users = new List<User>();

                string? jwt = Request.Cookies["jwt"];
                jwt = jwt!.ToString();
                var quantity = int.MaxValue;
                string url = $"http://localhost:5201/Voucher/GetAll?page=1&quantity={quantity}";
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
                    users = JsonConvert.DeserializeObject<IList<User>>(responseBody)!;
                    count = Math.Ceiling((double)users.Count / 10);
                }
                else
                {
                    count = 1;
                }

                //Count = await CountMaxPage();

                return count;
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}
