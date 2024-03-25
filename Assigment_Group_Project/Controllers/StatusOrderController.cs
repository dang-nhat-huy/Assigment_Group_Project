using BusinessObject.CustomMessage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusOrderController : Controller
    {
        private readonly IStatusOrderService _statusOrderService;
        public StatusOrderController(IStatusOrderService statusOrderService)
        {
            _statusOrderService = statusOrderService;
        }
        [HttpGet("GetAll", Name = "Get All Order Status")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _statusOrderService.GetAll(page, quantity);
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
