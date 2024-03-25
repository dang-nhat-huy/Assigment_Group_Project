using Assignment_Group_Project_RazorPages.ViewModel;
using BusinessObject.CustomMessage;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;

namespace Assignment_Group_Project_RazorPages.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginUserViewModel LoginUser { get; set; } = null!;
        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString("Role");
            string? jwt = Request.Cookies["jwt"];
            if (role == null || jwt == null)
            {
                return Page();
            }
            if (role.Equals("Manager"))
            {
                return RedirectToPage("./UserPages/Index");
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

                var email = LoginUser.Email;
                var password = LoginUser.Password;
                string url = $"http://localhost:5201/User/Login?email={email}&password={password}";

                var client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url)
                };
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string jwt = await response.Content.ReadAsStringAsync();
                    var jwtHandler = new JwtSecurityTokenHandler();
                    var token = jwtHandler.ReadToken(jwt) as JwtSecurityToken;
                    var role = token!.Claims.FirstOrDefault(c => c.Type == "role")!.Value;

                    // Set the cookie
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.UtcNow.AddHours(1),
                        HttpOnly = true,
                        Path = "/"
                    };
                    Response.Cookies.Append("jwt", jwt, cookieOptions);

                    //Set Session
                    HttpContext.Session.SetString("role", role);

                    TempData["success"] = "Login Successfully";
                    if (role.Equals("Manager"))
                    {
                        return RedirectToPage("./UserPages/Index");
                    }
                    else if(role.Equals("Staff"))
                    {
                        return Page();
                    }
                    else 
                    {
                        return Page();
                    }
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    TempData["error"] = error;
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
