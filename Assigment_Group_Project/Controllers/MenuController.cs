using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Service.IService;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("GetById")]
        //[Authorize(Roles = "Admin,Staff,Customer")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _menuService.GetById(id);
                if (product == null)
                {
                    return NotFound("Cannot Find Menu");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [EnableQuery(PageSize = 10)]
        [HttpGet("GetAll")]
        //[Authorize(Roles = "Admin,Staff,Customer")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var list = _menuService.GetAllWithInclude().AsQueryable();
                if (!list.Any())
                {
                    return NotFound("There's No Data");
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
