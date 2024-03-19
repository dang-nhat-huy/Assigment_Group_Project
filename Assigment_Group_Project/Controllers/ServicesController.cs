using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.Service;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicesController : ControllerBase 
    {
        private readonly IServicesService _servicesService;
        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpGet("GetById/{id}", Name = "Get Services By ID")]
        //[Authorize(Roles = "Admin,Staff,Customer")]
        public IActionResult GetServicesById([FromRoute] int id)
        {
            try
            {
                var product = _servicesService.GetById(id);
                if (product == null)
                {
                    return NotFound("Cannot Find Services");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        //[Authorize(Roles = "Admin,Staff,Customer")]
        public IActionResult GetAllServices(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _servicesService.GetAll(page, quantity);
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

        [HttpDelete("Delete/{id}", Name = "Delete Services")]
        public IActionResult DeleteServices([FromRoute] long id)
        {
            try
            {
                var deleteServicesItem = _servicesService.GetById(id);
                if (deleteServicesItem == null)
                {
                    return NotFound();
                }

                _servicesService.Delete(deleteServicesItem);
                _servicesService.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
