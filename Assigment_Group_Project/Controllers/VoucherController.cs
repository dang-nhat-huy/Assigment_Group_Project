using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.CustomMessage;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.ReponseModel;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _service;
        private readonly IMapper _mapper;

        public VoucherController(IVoucherService Voucherservice, IMapper mapper)
        {
            _service = Voucherservice;
            _mapper = mapper;
        }
        [HttpGet("GetAll", Name = "Get All Voucher")]
        public IActionResult GetAllVoucher(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _service.GetAll(page, quantity);
                var ListVoucher = _mapper.Map<List<VoucherViewModel>>(list);
                if (!list.Any())
                {
                    return NotFound(ReturnMessage.EMPTY_LIST);
                }
                return Ok(ListVoucher);
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
                var viewVoucher = _mapper.Map<VoucherViewModel>(Voucher);
                if (Voucher == null)
                {
                    return NotFound(ReturnMessage.VOUCHER_NOT_FOUND);
                }
                return Ok(viewVoucher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add", Name = "Add New Voucher")]
        public IActionResult AddVoucher(VoucherViewModel Vvoucher)
        {
            var voucher = _mapper.Map<Voucher>(Vvoucher);
            voucher.ExpireDate = new DateTime(Vvoucher.ExpireYear, Vvoucher.ExpireMonth, Vvoucher.ExpireDay, Vvoucher.ExpireHour, Vvoucher.ExpireMinute, 00);
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                var checkAdd = _service.AddVoucher(voucher);
                if (checkAdd == null)
                {
                    return BadRequest(new BaseFailedResponseModel
                    {
                        Status = BadRequest().StatusCode,
                        Message = "Add fail!",
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            _service.Save();
            return Ok(voucher);
        }
        [HttpPatch("Update/{id}", Name = "Update Existing Voucher")]
        public IActionResult UpdateVoucher([FromRoute] long id, VoucherViewModel Vvoucher)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                var existVoucher = _service.GetById(id);

                if (existVoucher == null)
                {
                    return NotFound(ReturnMessage.VOUCHER_NOT_FOUND);
                }
                //if (!existVoucher.VoucherId!.Equals(voucher.VoucherId))
                //{
                //    var existVoucher = _service.GetAll().Where(x => x.VoucherId!.Equals(voucher.VoucherId, StringComparison.OrdinalIgnoreCase));
                //    if (existVoucher.Any())
                //    {
                //        return BadRequest();
                //    }
                //}
                else
                {
                    existVoucher.ExpireDate = new DateTime(Vvoucher.ExpireDay, Vvoucher.ExpireMonth, Vvoucher.ExpireDay, Vvoucher.ExpireHour, Vvoucher.ExpireMinute, 00);
                    existVoucher.Code = Vvoucher.Code;
                    existVoucher.Note = Vvoucher.Note;
                    existVoucher.Discount = Vvoucher.Discount;
                }
                _service.Update(existVoucher);
                _service.Save();

                return Ok(_mapper.Map<VoucherViewModel>(existVoucher));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
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
                return Ok(ReturnMessage.DELETE_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

