using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.CustomMessage;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.Service;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;
        private readonly IMapper _mapper;
        public UserTaskController(IUserTaskService userTaskService, IMapper mapper)
        {
            _userTaskService = userTaskService;
            _mapper = mapper;
        }

        [HttpGet("GetAllUserTasks", Name = "Get All User Tasks")]
        [Authorize(Roles = "Admin,Manager,Staff,Customer")]
        public IActionResult GetAllUserTasks(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _userTaskService.GetAll(page, quantity);
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

        [HttpDelete("Delete/{id}", Name = "Delete User Task")]
        [Authorize(Roles = "Manager")]
        public IActionResult DeleteUserTask([FromRoute] long id)
        {
            try
            {
                var task = _userTaskService.GetById(id);
                if (task == null)
                {
                    return NotFound(ReturnMessage.USER_TASK_NOT_FOUND);
                }

                _userTaskService.Delete(task);
                _userTaskService.Save();
                return Ok(ReturnMessage.DELETE_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddUserTask", Name = "Add New User Task")]
        //[Authorize(Roles = "Manager")]
        public IActionResult AddUserTask(UserTaskRequestVM userTask)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                UserTask newTask = _mapper.Map<UserTask>(userTask);
                _userTaskService.Add(newTask);
                _userTaskService.Save();

                return Ok(ReturnMessage.ADD_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
