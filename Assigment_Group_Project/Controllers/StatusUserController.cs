using BusinessObject.CustomMessage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Service.IService;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusUserController : ControllerBase
    {
        private readonly IStatusUserService _statusUserService;
        public StatusUserController(IStatusUserService statusUserService)
        {
            _statusUserService = statusUserService;
        }
        [HttpGet("GetAll", Name = "Get All User Status")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetAll(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _statusUserService.GetAll(page, quantity);
                if(list == null) {
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
