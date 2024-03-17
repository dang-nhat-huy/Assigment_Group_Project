using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Service.IService;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase 
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("GetById/{id}", Name = "Get Menu Item By ID")]
        //[Authorize(Roles = "Admin,Staff,Customer")]
        public IActionResult GetMenuItemById(int id)
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
        public IActionResult GetAllMenuItems(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _menuService.GetAll(page,quantity);
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

        //[HttpPost("Add")]
        //[Authorize(Roles = "Staff")]
        //public IActionResult Add(AddMenuItemRequestVM request)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest("Invalid Input");
        //        }
        //        var existMenuItem = _productService.GetAll().Where(x => x.MenuItemName!.Equals(request.MenuItemName));
        //        if (existMenuItem.Any())
        //        {
        //            return BadRequest("There's already product with the same name");
        //        }

        //        MenuItem newMenuItem = new MenuItem
        //        {
        //            MenuItemName = request.MenuItemName,
        //            Amount = request.Amount,
        //            Description = request.Description,
        //            Price = request.Price,
        //            ReleaseYear = request.ReleaseYear,
        //            Version = request.Version,
        //            StatusId = 1,
        //        };
        //        _productService.Add(newMenuItem);
        //        _productService.Save();

        //        return Ok("Add Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
