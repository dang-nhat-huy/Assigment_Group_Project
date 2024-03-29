﻿using Assigment_Group_Project.ViewModel;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailServices _orderDetailServices;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper, IOrderDetailServices orderDetailServices)
        {
            _orderService = orderService;
            _mapper = mapper;
            _orderDetailServices = orderDetailServices;
        }

        [HttpGet("GetAll", Name = "Get All Orders")]
        [Authorize(Roles = "Admin,Manager,Staff")]
        public IActionResult GetAllOrders(int? page = 1, int? quanity = 10) {
            try
            {
                var list = _orderService.GetAll(page, quanity);
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
        [HttpGet("GetAllActive", Name = "Get All Active Orders")]
        [Authorize(Roles = "Admin,Manager,Staff,Customer")]
        public IActionResult GetAllActiveOrders(int? page = 1, int? quanity = 10)
        {
            try
            {
                var list = _orderService.GetAll(page, quanity).Where(x => x.StatusOrderId == 1);
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
        [HttpPost("Add", Name = "Create New Order From User")]
        [Authorize(Roles = "Customer")]
        public IActionResult CreateOrderUser(OrderRequestVM order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var newOrder = _mapper.Map<Order>(order);
                newOrder.StatusOrderId = 1;
                _orderService.Add(newOrder);
                _orderService.Save();

                return Ok(ReturnMessage.ADD_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("Update/{id}", Name = "Update Order From User")]
        [Authorize(Roles = "Customer")]
        public IActionResult UpdateOrder([FromRoute] long id, OrderRequestVM order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                var updateOrder = _orderService.GetById(id);
                if(updateOrder == null) {
                    return NotFound(ReturnMessage.ORDER_NOT_FOUND);
                }

                updateOrder = _mapper.Map(order, updateOrder);
                _orderService.Update(updateOrder);
                _orderService.Save();

                return Ok(ReturnMessage.UPDATE_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("ChangeStatus/{id}", Name = "Change Order Status")]
        [Authorize(Roles = "Manager,Staff")]
        public IActionResult ChangeStatus([FromRoute] long id, long statusId)
        {
            try
            {
                var order = _orderService.GetById(id);
                if(order == null) {
                    return NotFound(ReturnMessage.ORDER_NOT_FOUND);
                }

                if(statusId <= 0 || statusId >= 4)
                {
                    statusId = 3;
                }

                order.StatusOrderId = statusId;
                _orderService.Update(order);
                _orderService.Save();

                return Ok(ReturnMessage.UPDATE_STATUS_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get/{id}")]
        [Authorize(Roles = "Manager,Staff")]
        public IActionResult GetOrderById([FromRoute] long id)
        {
            try
            {
                var order = _orderService.GetAll().FirstOrDefault(x => x.OrderId == id);
                if (order== null)
                {
                    return NotFound(ReturnMessage.ORDER_NOT_FOUND);
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetOrderDetail/orderId/{orderId}")]
        [Authorize(Roles = "Admin,Manager,Staff,Customer")]
        public IActionResult GetOrderDetailByOrderId([FromRoute] long orderId)
        {
            try
            {
                var orderDetails = _orderDetailServices.GetAll().Where(x => x.OrderId == orderId);
                if(orderDetails == null )
                {
                    return NotFound(ReturnMessage.EMPTY_LIST);
                }
                return Ok(orderDetails);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetOrderDetail/orderDetailId/{id}")]
        [Authorize(Roles = "Admin,Manager,Staff,Customer")]
        public IActionResult GetOrderDetailById([FromRoute] long id)
        {
            try
            {
                var orderDetail = _orderDetailServices.GetAll().FirstOrDefault(x => x.OrderDetailId == id);
                if (orderDetail == null)
                {
                    return NotFound(ReturnMessage.ORDER_DETAIL_NOT_FOUND);
                }
                return Ok(orderDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddOrderDetail", Name = "Create New Order Detail From User")]
        [Authorize(Roles = "Customer")]
        public IActionResult CreateOrderDetailUser(OrderDetailRequestVM request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var order = _orderService.GetById((long)request.OrderId!);
                if(order == null)
                {
                    return NotFound(ReturnMessage.ORDER_NOT_FOUND);
                }

                var newOrderDetail = _mapper.Map<OrderDetail>(request);
                newOrderDetail.Commission = order!.TotalFees*5/100;
                _orderDetailServices.Add(newOrderDetail);
                _orderDetailServices.Save();

                return Ok(ReturnMessage.ADD_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("UpdateOrderDetail/{id}", Name = "Update Order Detail From User")]
        [Authorize(Roles = "Customer")]
        public IActionResult UpdateOrderDetail([FromRoute] long id, OrderDetailUpdateRequestVM request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                var updateOrderDetail = _orderDetailServices.GetById(id);
                if (updateOrderDetail == null)
                {
                    return NotFound(ReturnMessage.ORDER_NOT_FOUND);
                }
                var order = _orderService.GetById((long)updateOrderDetail.OrderId!);
                if (order == null)
                {
                    return NotFound(ReturnMessage.ORDER_NOT_FOUND);
                }

                updateOrderDetail = _mapper.Map(request, updateOrderDetail);
                updateOrderDetail.Commission = order.TotalFees * 5/100;
                _orderDetailServices.Update(updateOrderDetail);
                _orderDetailServices.Save();

                return Ok(ReturnMessage.UPDATE_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
