using Assigment_Group_Project.ViewModel;
using AutoMapper;
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
        public IActionResult GetAllTasks(int? page = 1, int? quantity = 10) {
            try
            {
                var list = _taskService.GetAll(page, quantity);
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
        [HttpGet("Get/{id}", Name = "Get Task By Id")]
        public IActionResult GetTaskById([FromRoute] long id)
        {
            try
            {
                var task = _taskService.GetById(id);
                if(task == null)
                {
                    return NotFound();
                }
                return Ok(task);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add", Name = "Add New Task")]
        public IActionResult AddTask(TaskRequestVM task)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                Task newTask = _mapper.Map<Task>(task);
                _taskService.Add(newTask);
                _taskService.Save();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("Update/{id}", Name = "Update Existing Task")]
        public IActionResult UpdateTask([FromRoute] long id, TaskRequestVM task)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existTask = _taskService.GetById(id);
                if(existTask == null)
                {
                    return NotFound();
                }
                if(!existTask.TaskName!.Equals(task.TaskName))
                {
                    var existTasks = _taskService.GetAll().Where(x => x.TaskName!.Equals(task.TaskName, StringComparison.OrdinalIgnoreCase));
                    if(existTasks.Any())
                    {
                        return BadRequest();
                    }
                }

                existTask = _mapper.Map(task, existTask);
                _taskService.Update(existTask);
                _taskService.Save();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}", Name = "Delete Task")]
        public IActionResult DeleteTask([FromRoute] long id)
        {
            try
            {
                var task = _taskService.GetById(id);
                if (task == null)
                {
                    return NotFound();
                }

                _taskService.Delete(task);
                _taskService.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
