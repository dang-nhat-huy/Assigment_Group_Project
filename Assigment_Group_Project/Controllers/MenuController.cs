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

        //[HttpPost("Add")]
        //[Authorize(Roles = "Staff")]
        //public IActionResult Add(AddProductRequestVM request)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest("Invalid Input");
        //        }
        //        var existProduct = _productService.GetAll().Where(x => x.ProductName!.Equals(request.ProductName));
        //        if (existProduct.Any())
        //        {
        //            return BadRequest("There's already product with the same name");
        //        }

        //        Product newProduct = new Product
        //        {
        //            ProductName = request.ProductName,
        //            Amount = request.Amount,
        //            Description = request.Description,
        //            Price = request.Price,
        //            ReleaseYear = request.ReleaseYear,
        //            Version = request.Version,
        //            StatusId = 1,
        //        };
        //        _productService.Add(newProduct);
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
