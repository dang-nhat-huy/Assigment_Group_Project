using BusinessObject.CustomMessage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusRoomController : ControllerBase
    {
        private readonly IStatusRoomService _statusRoomService;
        public StatusRoomController(IStatusRoomService statusRoomService)
        {
            _statusRoomService = statusRoomService;
        }
        [HttpGet("GetAll", Name = "Get All Room Status")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _statusRoomService.GetAll(page, quantity);
                if(!list.Any())
                {
                    return NotFound(ReturnMessage.EMPTY_LIST);
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
