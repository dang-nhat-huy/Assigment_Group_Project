using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("GetAll", Name = "Get All Orders")]
        public IActionResult GetAllOrders(int? page = 1, int? quanity = 10) {
            try
            {
                var list = _orderService.GetAll(page, quanity);
                if(!list.Any())
                {
                    return NotFound();
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllActive", Name = "Get All Active Orders")]
        public IActionResult GetAllActiveOrders(int? page = 1, int? quanity = 10)
        {
            try
            {
                var list = _orderService.GetAll(page, quanity).Where(x => x.StatusId == 1);
                if (!list.Any())
                {
                    return NotFound();
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add", Name = "Create New Order From User")]
        public IActionResult CreateOrderUser(OrderRequestVM order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var newOrder = _mapper.Map<Order>(order);
                newOrder.StatusId = 1;
                _orderService.Add(newOrder);
                _orderService.Save();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("Update/{id}", Name = "Update Order From User")]
        public IActionResult UpdateOrder([FromRoute] long id, OrderRequestVM order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var updateOrder = _orderService.GetById(id);
                if(updateOrder == null) {
                    return NotFound();
                }

                updateOrder = _mapper.Map(order, updateOrder);
                _orderService.Update(updateOrder);
                _orderService.Save();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("ChangeStatus/{id}", Name = "Change Order Status")]
        public IActionResult ChangeStatus([FromRoute] long id)
        {
            try
            {
                var order = _orderService.GetById(id);
                if(order == null) {
                    return NotFound();
                }

                switch (order.StatusId)
                {
                    case 1:
                        order.StatusId = 2;
                        break;
                    case 2:
                        order.StatusId = 3;
                        break;
                    case 3:
                        order.StatusId = 3;
                        break;
                    default:
                        order.StatusId = 3;
                        break;
                }
                _orderService.Update(order);
                _orderService.Save();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
