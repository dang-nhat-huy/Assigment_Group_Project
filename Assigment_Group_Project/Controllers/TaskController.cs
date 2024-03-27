using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.CustomMessage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Task = BusinessObject.Models.Task;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }
        [HttpGet("GetAll", Name = "Get All Tasks")]
        [Authorize(Roles = "Admin,Manager,Staff,Customer")]
        public IActionResult GetAllTasks(int? page = 1, int? quantity = 10) {
            try
            {
                var list = _taskService.GetAll(page, quantity);
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
        [HttpGet("Get/{id}", Name = "Get Task By Id")]
        [Authorize(Roles = "Admin,Manager,Staff,Customer")]
        public IActionResult GetTaskById([FromRoute] long id)
        {
            try
            {
                var task = _taskService.GetById(id);
                if(task == null)
                {
                    return NotFound(ReturnMessage.TASK_NOT_FOUND);
                }
                return Ok(task);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add", Name = "Add New Task")]
        [Authorize(Roles = "Manager")]
        public IActionResult AddTask(TaskRequestVM task)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                Task newTask = _mapper.Map<Task>(task);
                _taskService.Add(newTask);
                _taskService.Save();

                return Ok(ReturnMessage.ADD_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("Update/{id}", Name = "Update Existing Task")]
        [Authorize(Roles = "Manager")]
        public IActionResult UpdateTask([FromRoute] long id, TaskRequestVM task)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                var existTask = _taskService.GetById(id);
                if(existTask == null)
                {
                    return NotFound(ReturnMessage.TASK_NOT_FOUND);
                }
                if(!existTask.TaskName!.Equals(task.TaskName))
                {
                    var existTasks = _taskService.GetAll().Where(x => x.TaskName!.Equals(task.TaskName, StringComparison.OrdinalIgnoreCase));
                    if(existTasks.Any())
                    {
                        return BadRequest(ReturnMessage.BAD_REQUEST);
                    }
                }

                existTask = _mapper.Map(task, existTask);
                _taskService.Update(existTask);
                _taskService.Save();

                return Ok(ReturnMessage.UPDATE_SUCCESS);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}", Name = "Delete Task")]
        [Authorize(Roles = "Manager")]
        public IActionResult DeleteTask([FromRoute] long id)
        {
            try
            {
                var task = _taskService.GetById(id);
                if (task == null)
                {
                    return NotFound(ReturnMessage.TASK_NOT_FOUND);
                }

                _taskService.Delete(task);
                _taskService.Save();
                return Ok(ReturnMessage.DELETE_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
