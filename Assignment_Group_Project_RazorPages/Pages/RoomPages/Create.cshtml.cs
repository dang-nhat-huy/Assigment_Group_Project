﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using Newtonsoft.Json;
using System.Text;

namespace Assignment_Group_Project_RazorPages.Pages.RoomPages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Room Room { get; set; } = default!;
        public IList<StatusRoom> StatusRooms { get; set; } = default!;
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

                StatusRooms = await GetAllRoomStatusAsync();
                ViewData["Status"] = new SelectList(StatusRooms, "StatusRoomId", "StatusName");

                return Page();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return Page();
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                string? jwt = Request.Cookies["jwt"]!.ToString();
                string url = $"http://localhost:5201/Room/Add";
                string jsonRoom = JsonConvert.SerializeObject(Room);
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Post,
                    Content = new StringContent(jsonRoom, Encoding.UTF8, "application/json")
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
                    StatusRooms = await GetAllRoomStatusAsync();
                    ViewData["Status"] = new SelectList(StatusRooms, "StatusRoomId", "StatusName");
                }
                return Page();
            }
            catch (Exception ex)
            {
                StatusRooms = await GetAllRoomStatusAsync();
                ViewData["Status"] = new SelectList(StatusRooms, "StatusRoomId", "StatusName");
                TempData["error"] = ex.Message;
                return Page();
            }
        }
        private async Task<IList<StatusRoom>> GetAllRoomStatusAsync()
        {
            try
            {
                IList<StatusRoom> status = new List<StatusRoom>();

                string? jwt = Request.Cookies["jwt"];
                jwt = jwt!.ToString();
                string url = $"http://localhost:5201/StatusRoom/GetAll";
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
                    status = JsonConvert.DeserializeObject<IList<StatusRoom>>(responseBody)!;
                }
                else
                {
                    status = new List<StatusRoom>();
                }

                return status;
            }
            catch (Exception)
            {
                return new List<StatusRoom>();
            }
        }
    }
}
