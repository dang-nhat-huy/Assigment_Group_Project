using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.CustomMessage;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserOrderController : Controller
    {
        private readonly IUserOrderService _userOrderService;
        private readonly IMapper _mapper;
        public UserOrderController(IUserOrderService userOrderService, IMapper mapper)
        {
            _userOrderService = userOrderService;
            _mapper = mapper;
        }

        [HttpGet("GetAllUserOrders", Name = "Get All User Orders")]
        //[Authorize(Roles = "Admin,Manager,Staff,Customer")]
        public IActionResult GetAllUserOrders(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _userOrderService.GetAll(page, quantity);
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

        [HttpDelete("Delete/{id}", Name = "Delete User Order")]
        //[Authorize(Roles = "Manager")]
        public IActionResult DeleteUserOrder([FromRoute] long id)
        {
            try
            {
                var task = _userOrderService.GetById(id);
                if (task == null)
                {
                    return NotFound(ReturnMessage.USER_ORDER_NOT_FOUND);
                }

                _userOrderService.Delete(task);
                _userOrderService.Save();
                return Ok(ReturnMessage.DELETE_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddUserOrder", Name = "Add New User Order")]
        //[Authorize(Roles = "Manager")]
        public IActionResult AddUserOrder(UserOrderRequestVM userOrder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                UserOrder newOrder = _mapper.Map<UserOrder>(userOrder);
                _userOrderService.Add(newOrder);
                _userOrderService.Save();

                return Ok(ReturnMessage.ADD_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
