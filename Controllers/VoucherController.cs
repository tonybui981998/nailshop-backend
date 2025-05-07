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
    }
}