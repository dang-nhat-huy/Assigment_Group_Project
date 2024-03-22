using Assigment_Group_Project.ViewModel;
using BusinessObject.CustomMessage;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.Service;
using Services = BusinessObject.Models.Service;

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
                    return NotFound(ReturnMessage.SERVICE_NOT_FOUND);
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
                    return NotFound(ReturnMessage.EMPTY_LIST);
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
                    return NotFound(ReturnMessage.SERVICE_NOT_FOUND);
                }

                _servicesService.Delete(deleteServicesItem);
                _servicesService.Save();

                return Ok(ReturnMessage.DELETE_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddService", Name = "Add New Services")]
        public IActionResult AddServices(string name, float price)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest(ReturnMessage.NULL_DATA);
                }
                if (name != null && name.Trim().Length > 50)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                var existServices = _servicesService.GetAll().Where(x => x.ServiceName!.Equals(name));
                if (existServices.Any())
                {
                    return BadRequest(ReturnMessage.DUPLICATE_NAME);
                }

                Services newServicesItem = new Services
                {
                    ServiceName = name,
                    Fee = price
                };

                _servicesService.Add(newServicesItem);
                _servicesService.Save();

                return Ok(ReturnMessage.ADD_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("UpdateServices/{id}", Name = "Update Existing Services")]
        public IActionResult UpdateServices([FromRoute] long id, ServiceRequestVM serviceRequestVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                //Get Item need to Update
                var updateServicesItem = _servicesService.GetById(id);
                if (updateServicesItem == null)
                {
                    return NotFound(ReturnMessage.SERVICE_NOT_FOUND);
                }

                if (updateServicesItem.Equals(serviceRequestVM.ServiceName))
                {
                    return BadRequest(ReturnMessage.DUPLICATE_NAME);
                }
                // Update price if provided, otherwise keep the current price
                if (serviceRequestVM.Fee.HasValue)
                {
                    updateServicesItem.Fee = serviceRequestVM.Fee.Value;
                }               
                else
                {
                    //Check if any item with name exist or not
                    var existServicesItem = _servicesService.GetAll().Where(x => x.ServiceName!.Equals(serviceRequestVM.ServiceName));
                    if (existServicesItem.Any())
                    {
                        return BadRequest(ReturnMessage.DUPLICATE_NAME);
                    }

                }
                updateServicesItem.ServiceName = serviceRequestVM.ServiceName;
                _servicesService.Update(updateServicesItem);
                _servicesService.Save();

                return Ok(ReturnMessage.UPDATE_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("SearchByName/{serviceName}", Name = "Search By Services Name")]
        //[Authorize(Roles = "Admin,Staff,Customer")]
        public IActionResult SearchServices([FromRoute] string serviceName, int? page = 1, int? quantity = 10)
        {
            try
            {
                var checkExist = _servicesService.GetAll(page, quantity).Where(x => x.ServiceName.ToLower().Contains(serviceName.ToLower())).ToList();
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
    }
}
