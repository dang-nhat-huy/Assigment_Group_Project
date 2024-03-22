using BusinessObject.Models;
using BusinessObject.CustomMessage;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("GetAll", Name = "Get All Categories")]
        public IActionResult GetAllCategories(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _categoryService.GetAll(page, quantity);
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
        [HttpGet("Get/{id}", Name = "Get Category By ID")]
        public IActionResult GetCategoryById([FromRoute] long id)
        {
            try
            {
                var category = _categoryService.GetById(id);
                if(category == null)
                {
                    return NotFound(ReturnMessage.CATEGORY_NOT_FOUND);
                }
                return Ok(category);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add", Name = "Add New Category")]
        public IActionResult AddCategory(string name)
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

                var existCategory = _categoryService.GetAll().Where(x => x.CategoriesName!.Equals(name));
                if (existCategory.Any())
                {
                    return BadRequest(ReturnMessage.DUPLICATE_NAME);
                }

                Category newCategory = new Category { CategoriesName = name };

                _categoryService.Add(newCategory);
                _categoryService.Save();

                return Ok(ReturnMessage.ADD_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("Update/{id}", Name = "Update Existing Category")]
        public IActionResult UpdateCategory([FromRoute] long id, string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest(ReturnMessage.NULL_DATA);
                }
                if(name != null && name.Trim().Length > 50)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                var updateCategory = _categoryService.GetById(id);
                if (updateCategory == null)
                {
                    return NotFound(ReturnMessage.CATEGORY_NOT_FOUND);
                }

                if (updateCategory.CategoriesName!.Equals(name))
                {
                    return BadRequest(ReturnMessage.DUPLICATE_NAME);
                }
                else
                {
                    var existCategory = _categoryService.GetAll().Where(x => x.CategoriesName!.Equals(name));
                    if (existCategory.Any())
                    {
                        return BadRequest(ReturnMessage.BAD_REQUEST);
                    }
                }

                updateCategory.CategoriesName = name;
                _categoryService.Update(updateCategory);
                _categoryService.Save();

                return Ok(ReturnMessage.UPDATE_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}", Name = "Delete Category")]
        public IActionResult DeleteCategory([FromRoute] long id)
        {
            try
            {
                var deleteCategory = _categoryService.GetById(id);
                if (deleteCategory == null)
                {
                    return NotFound(ReturnMessage.CATEGORY_NOT_FOUND);
                }

                _categoryService.Delete(deleteCategory);
                _categoryService.Save();

                return Ok(ReturnMessage.DELETE_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
