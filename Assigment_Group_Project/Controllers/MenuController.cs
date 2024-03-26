using Assigment_Group_Project.ViewModel;
using BusinessObject.CustomMessage;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.OData.Query;
using Service.IService;
using Service.Service;

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
        public IActionResult GetMenuItemById([FromRoute] int id)
        {
            try
            {
                var product = _menuService.GetById(id);
                if (product == null)
                {
                    return NotFound(ReturnMessage.MENU_NOT_FOUND);
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin,Manager,Staff,Customer")]
        public IActionResult GetAllMenuItems(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _menuService.GetAll(page, quantity);
                if (!list.Any())
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

        [HttpGet("SearchByName/{productName}", Name = "Search By Menu Item Name")]
        //[Authorize(Roles = "Admin,Staff,Customer")]
        public IActionResult SearchMenuItems([FromRoute] string productName, int? page = 1, int? quantity = 10)
        {
            try
            {
                var checkExist = _menuService.GetAll(page, quantity).Where(x => x.MenuItem!.ToLower().Contains(productName.ToLower())).ToList();
                if (checkExist == null)
                {
                    return NotFound(ReturnMessage.EMPTY_LIST);
                }
                return Ok(checkExist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}", Name = "Delete Menu Item")]
        public IActionResult DeleteMenuItem([FromRoute] long id)
        {
            try
            {
                var deleteMenuItem = _menuService.GetById(id);
                if (deleteMenuItem == null)
                {
                    return NotFound(ReturnMessage.MENU_NOT_FOUND);
                }

                _menuService.Delete(deleteMenuItem);
                _menuService.Save();

                return Ok(ReturnMessage.DELETE_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Update/{id}", Name = "Update Existing Menu Item")]
        public IActionResult UpdateMenuItem([FromRoute] long id, string? name, float? price, long? menuID)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest(ReturnMessage.NULL_DATA);
                }
                if (name != null && name.Trim().Length > 50)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                //Get Item need to Update
                var updateMenuItem = _menuService.GetById(id);
                if (updateMenuItem == null)
                {
                    return NotFound(ReturnMessage.MENU_NOT_FOUND);
                }

                if (updateMenuItem.Equals(name))
                {
                    return BadRequest(ReturnMessage.DUPLICATE_NAME);
                }
                // Update price if provided, otherwise keep the current price
                if (price.HasValue)
                {
                    updateMenuItem.Price = price.Value;
                }
                else
                {
                    //Check if any item with name exist or not
                    var existMenuItem = _menuService.GetAll().Where(x => x.MenuItem!.Equals(name));
                    if (existMenuItem.Any())
                    {
                        return BadRequest(ReturnMessage.DUPLICATE_NAME);
                    }

                }
                updateMenuItem.MenuItem = name;
                _menuService.Update(updateMenuItem);
                _menuService.Save();

                return Ok(ReturnMessage.UPDATE_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add", Name = "Add New Menu Item")]
        public IActionResult AddMenu(string name, float price, long categoryID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest(ReturnMessage.NULL_DATA);
                }
                if (name != null && name.Trim().Length > 50)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                var existMenu = _menuService.GetAll().Where(x => x.MenuItem!.Equals(name));
                if (existMenu.Any())
                {
                    return BadRequest(ReturnMessage.DUPLICATE_NAME);
                }

                Menu newMenuItem = new Menu
                {
                    MenuItem = name,
                    Price = price,
                    CategoriesId = categoryID
                };

                _menuService.Add(newMenuItem);
                _menuService.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
