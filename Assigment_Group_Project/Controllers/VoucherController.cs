using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoucherController : ControllerBase
    {

    
        private readonly IVoucherService _service;
        public VoucherController(IVoucherService _service)
        {
            _service = _service;
        }
        [HttpGet("GetAll", Name = "Get All Tasks")]
        public IActionResult GetAllTasks(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _service.GetAll(page, quantity);
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
        [HttpGet("Get/{id}", Name = "Get Task By Id")]
        public IActionResult GetTaskById([FromRoute] long id)
        {
            try
            {
                var task = _service.GetById(id);
                if (task == null)
                {
                    return NotFound();
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add", Name = "Add New Task")]
        public IActionResult AddTask(Voucher voucher)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _service.Add(voucher);
                _service.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("Update/{id}", Name = "Update Existing Task")]
        public IActionResult UpdateTask([FromRoute] Voucher voucher)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existTask = _service.GetById(voucher.VoucherId);
                if (existTask == null)
                {
                    return NotFound();
                }
                //if (!existTask.VoucherId!.Equals(voucher.VoucherId))
                //{
                //    var existTasks = _service.GetAll().Where(x => x.VoucherId!.Equals(voucher.VoucherId, StringComparison.OrdinalIgnoreCase));
                //    if (existTasks.Any())
                //    {
                //        return BadRequest();
                //    }
                //}
                else
                {
                    existTask = voucher;
                }
                _service.Update(existTask);
                _service.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}", Name = "Delete Task")]
        public IActionResult DeleteTask([FromRoute] long id)
        {
            try
            {
                var task = _service.GetById(id);
                if (task == null)
                {
                    return NotFound();
                }

                _service.Delete(task);
                _service.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
}
