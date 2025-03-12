using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.BookingDto;
using backend.DataMapper;
using backend.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController :ControllerBase
    {
        private readonly IBookingRepository _bookingRepo;
        public BookingController(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }
        [HttpPost("createBooking")]
        public async Task<IActionResult>CreateBooking([FromBody] BookingDto bookingModel){
            if(bookingModel == null || bookingModel.bookingServices == null){
            return BadRequest("Sorry missing information");
            }
            var makebooking = bookingModel.ToCreateBooking();
            var clientBooking = bookingModel.bookingServices.Select(x=>x.ToCreateClientBooking()).ToList();
            var createBooking = await _bookingRepo.CreateBookingAsync(makebooking,clientBooking);
            return Ok("Create success");
        }
        [HttpGet("getBookingInfor")]
        public async Task<IActionResult>GetAllBookingData(){

            var alllBooking = await _bookingRepo.GetBookingTime();
            return Ok(alllBooking);
        }
        
    }
}