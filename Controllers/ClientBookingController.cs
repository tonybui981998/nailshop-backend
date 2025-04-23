using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.Bookingdto;
using backend.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
      [ApiController]
      [Route("api/clientBooking")]
    public class ClientBookingController :ControllerBase
    {
      private readonly IClientBookingRepository _clientRepo;
      public ClientBookingController(IClientBookingRepository clientRepo)
      {
        _clientRepo = clientRepo;
      }
      [HttpDelete("delete-service")]
      public async Task<IActionResult>DeleteService([FromBody] ClientDeleteServiceDto dto){
        var deleteService = await _clientRepo.DeleteServiceAsync(dto);
        if(deleteService == null){
            return Ok(new {status = "error",message = "sorry something wrong"});
        }
        return Ok(new {status = "success",message="delete success"});
      }

    }
}