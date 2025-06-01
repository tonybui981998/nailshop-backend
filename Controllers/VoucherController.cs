using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.VoucherDto;
using backend.DataMapper;
using backend.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/voucher")]
    public class VoucherController :ControllerBase
    {
        private readonly IVoucherRepository _voucherRepo;
        public VoucherController(IVoucherRepository voucherRepo)
        {
            _voucherRepo = voucherRepo;
        }
[HttpPost("check-voucher")]
public async Task<ActionResult<VoucherRepondDto>> CheckVoucher([FromBody] VoucherCheckDto voucherCheckDto){

    var check = await _voucherRepo.CheckExistAsync(voucherCheckDto);
    if(check == null){
        return Ok(new {status = "error",message ="sorry something wrong"});
    }
    var respond = check.TogetCheckVoucher();
    return Ok(respond);
}
[HttpPost("confirm-voucher")]
        public async Task<IActionResult>SendVoucherToCustomer([FromBody]GetVoucherCodeDto getVoucherCodeDto){
            if(getVoucherCodeDto.Username == null || getVoucherCodeDto.Email == null || getVoucherCodeDto.TotalAmount == null || getVoucherCodeDto.RemainingAmount == null){
                return Ok(new {status = "error", message = "sorry missing information"});
            }
            var createCode = await _voucherRepo.GetAuoGenetaCodeAsync(getVoucherCodeDto);
            if(createCode == null){
                return Ok(new {status ="error",message = "sorry faild to get the code"});
            }
   
            try{
               await _voucherRepo.SendEmailAsync(getVoucherCodeDto,createCode.Code);
            }catch(Exception ex){
                return Ok(new {status = "error",message = ex.Message});
            }
            return Ok(new {status = "success",message = "Email already send to customer"});
        }
    
    }
}