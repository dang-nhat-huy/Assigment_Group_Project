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
        public VoucherController(IVoucherService Voucherservice)
        {
            _service = Voucherservice;
        }
        [HttpGet("GetAll", Name = "Get All Voucher")]
        public IActionResult GetAllVoucher(int? page = 1, int? quantity = 10)
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
        [HttpGet("Get/{id}", Name = "Get Voucher By Id")]
        public IActionResult GetVoucherById([FromRoute] long id)
        {
            try
            {
                var Voucher = _service.GetById(id);
                if (Voucher == null)
                {
                    return NotFound();
                }
                return Ok(Voucher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add", Name = "Add New Voucher")]
        public IActionResult AddVoucher(Voucher voucher)
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
        //[HttpPatch("Update/{id}", Name = "Update Existing Voucher")]
        //public IActionResult UpdateVoucher([FromRoute] Voucher voucher)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest();
        //        }

        //        var existVoucher = _service.GetById(voucher.VoucherId);
        //        if (existVoucher == null)
        //        {
        //            return NotFound();
        //        }
        //        //if (!existVoucher.VoucherId!.Equals(voucher.VoucherId))
        //        //{
        //        //    var existVoucher = _service.GetAll().Where(x => x.VoucherId!.Equals(voucher.VoucherId, StringComparison.OrdinalIgnoreCase));
        //        //    if (existVoucher.Any())
        //        //    {
        //        //        return BadRequest();
        //        //    }
        //        //}
        //        else
        //        {
        //            existVoucher = voucher;
        //        }
        //        _service.Update(existVoucher);
        //        _service.Save();

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpDelete("Delete/{id}", Name = "Delete Voucher")]
        public IActionResult DeleteVoucher([FromRoute] long id)
        {
            try
            {
                var Voucher = _service.GetById(id);
                if (Voucher == null)
                {
                    return NotFound();
                }

                _service.Delete(Voucher);
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

