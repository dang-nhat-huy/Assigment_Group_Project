using Assignment_Group_Project_RazorPages.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Text;

namespace Assignment_Group_Project_RazorPages.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public SignUpUserViewModel SignUpUser { get; set; } = null!;
        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString("role");
            string? jwt = Request.Cookies["jwt"];
            if (role == null || jwt == null)
            {
                return Page();
            }
            if (role.Equals("Admin"))
            {
                return Page();
            }
            else
            {
                return Page();
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }
                string url = "http://localhost:5201/User/SignUp";
                string jsonUser = JsonConvert.SerializeObject(SignUpUser);
                var client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(jsonUser, Encoding.UTF8, "application/json")
                };
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    TempData["success"] = message;
                    return RedirectToPage("./Login");
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    TempData["error"] = message;
                    return Page();
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return Page();
            }
        }
    }
}
