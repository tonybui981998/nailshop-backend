using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.BookingConfirm;
using backend.DataDto.VoucherUsage;
using backend.DataMapper;
using backend.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/confirm")]
    public class BookingConfirmController :ControllerBase
    {
        private readonly IBookingConfirmRepository _bookingRepo;
        private readonly IVoucherRepository _voucherRepo;
        private readonly IVoucherUsageRepository _useRepo;
        public BookingConfirmController(IBookingConfirmRepository bookingRepo, IVoucherRepository voucherRepo,IVoucherUsageRepository useRepo)
        {
            _bookingRepo = bookingRepo;
            _voucherRepo = voucherRepo;
            _useRepo = useRepo; 
        }
        
        [HttpPost("check-out")]
        public async Task <IActionResult> CreateCheckOut ([FromBody] ConfirmcheckOutDto confirmcheckOutDto){
            if(confirmcheckOutDto == null){
                return BadRequest("sorry missing information");
            }
            var createBookingConfirm = confirmcheckOutDto.BookingConfirmDto.TogetConfirmBooking();
            var confirmService = confirmcheckOutDto.BookingConfirmDto.Service.Select(x=>x.TogetConfirmService()).ToList();
            var creatBooking = await _bookingRepo.CreateBookingConfirmAsync(createBookingConfirm,confirmService);
            
            if (confirmcheckOutDto.BookingConfirmDto?.VoucherCode != null)
            {
                var check = await _voucherRepo.CheckVoucherAsync(confirmcheckOutDto.BookingConfirmDto.VoucherCode, confirmcheckOutDto.BookingConfirmDto.RemainingMoney);
                if (check == null)
                {
                    return BadRequest("sorry something wrong");
                }
                else
                {
                    confirmcheckOutDto.VoucherUsageDto.BookingConfirmId = creatBooking.Id;
                    var createUsage = await _useRepo.CreateUseAsync(confirmcheckOutDto.VoucherUsageDto);
                    if (createUsage == null)
                    {
                        return BadRequest("sorry create use failed");
                    }
                  
                }

            }
             if (creatBooking.BookingStatus == "confirmed")
            {
                await _bookingRepo.SenBillConfirm(creatBooking.CusName,creatBooking.TotalPay,confirmcheckOutDto.BookingConfirmDto.email);
            }
            else if (creatBooking.BookingStatus == "did-not-come")
            {
              await _bookingRepo.SendDidnotComeNotice(creatBooking.CusName,confirmcheckOutDto.BookingConfirmDto.email);
            }

            return Ok("success");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CheckBooking([FromRoute] int id){
            var check = await _bookingRepo.CheckExistAsync(id);
            if(check == null){
                return Ok(new {status = "notfound",message ="sorry Id not found"});
            }
            return Ok(new {status = "success",message ="success"});
        }
        [HttpGet("get-bookingconfirm")]
        public async Task<IActionResult> GetBookingConfirm(){
            var result = await _bookingRepo.GetAllBookingConfirmAsync();
            if(result == null){
                return Ok(new {status ="error",message ="sorry something wrong"});
            }
            return Ok(result);
        }
    }
}