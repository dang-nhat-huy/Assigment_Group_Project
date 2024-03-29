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
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        private readonly IStatusRoomService _statusRoomService;
        public RoomController(IRoomService roomService, IMapper mapper, IStatusRoomService statusRoomService)
        {
            _roomService = roomService;
            _mapper = mapper;
            _statusRoomService = statusRoomService;
        }
        [HttpGet("GetAll", Name = "Get All Rooms")]
        [Authorize(Roles = "Admin,Manager,Staff,Customer")]
        public IActionResult GetAllRooms(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _roomService.GetAll(page, quantity);
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
        [HttpGet("Get/{id}", Name = "Get Room By ID")]
        [Authorize(Roles = "Admin,Manager,Staff,Customer")]
        public IActionResult GetById([FromRoute] long id)
        {
            try
            {
                var room = _roomService.GetById(id);
                if (room == null)
                {
                    return NotFound(ReturnMessage.ROOM_NOT_FOUND);                    
                }
                return Ok(room);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("ChangeStatus/{id}", Name = "Change A Room Status")]
        [Authorize(Roles = "Manager")]
        public IActionResult ChangeStatus([FromRoute] long id, long statusId)
        {
            try
            {
                var room = _roomService.GetById(id);
                if (room == null)
                {
                    return NotFound(ReturnMessage.ROOM_NOT_FOUND);
                }

                var status = _statusRoomService.GetAll().Where(x => x.StatusRoomId == statusId);
                if (!status.Any())
                {
                    return BadRequest(ReturnMessage.INVALID_DATA);
                }

                room.StatusRoomId = statusId;
                _roomService.Update(room);
                _roomService.Save();

                return Ok(ReturnMessage.UPDATE_STATUS_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}", Name = "Delete A Room")]
        [Authorize(Roles = "Manager")]
        public IActionResult Delete([FromRoute] long id)
        {
            try
            {
                var room = _roomService.GetById(id);
                if (room == null)
                {
                    return NotFound(ReturnMessage.ROOM_NOT_FOUND);
                }

                _roomService.Delete(room);
                _roomService.Save();

                return Ok(ReturnMessage.DELETE_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add", Name = "Add A Room")]
        [Authorize(Roles = "Manager")]
        public IActionResult Add(RoomRequestVM request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }

                var existRoomName = _roomService.GetAll().Where(x => x.RoomName!.Equals(request.RoomName, StringComparison.OrdinalIgnoreCase));
                if (existRoomName.Any())
                {
                    return BadRequest(ReturnMessage.DUPLICATE_NAME);
                }

                var newRoom = _mapper.Map<Room>(request);
                newRoom.StatusRoomId = 2;
                _roomService.Add(newRoom);
                _roomService.Save();

                return Ok(ReturnMessage.ADD_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("Update/{id}", Name = "Update A Room")]
        [Authorize(Roles = "Manager,Staff")]
        public IActionResult Update([FromRoute] long id, RoomRequestVM request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }

                var room = _roomService.GetById(id);
                if (room == null)
                {
                    return NotFound(ReturnMessage.ROOM_NOT_FOUND);
                }

                if(!room.RoomName!.Equals(request.RoomName, StringComparison.OrdinalIgnoreCase))
                {
                    var existRoomName = _roomService.GetAll().Where(x => x.RoomName!.Equals(request.RoomName, StringComparison.OrdinalIgnoreCase));
                    if (existRoomName.Any())
                    {
                        return BadRequest(ReturnMessage.DUPLICATE_NAME);
                    }
                }

                room = _mapper.Map(request, room);
                _roomService.Update(room);
                _roomService.Save();

                return Ok(ReturnMessage.UPDATE_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
