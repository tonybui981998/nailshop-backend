using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.CustomScheduleDto;
using backend.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/custom")]
    public class CustomScheduleController : ControllerBase
    {
        private readonly ICustomScheduleRepository _customRepo;

        public CustomScheduleController(ICustomScheduleRepository customRepo)
        {
            _customRepo = customRepo;
        }

        [HttpPost("reschedule")]
        /* public async Task<IActionResult> CustomSchedule([FromBody] EditCustomSchedule editCustomSchedule)
         {
             try
             {
                  if (editCustomSchedule == null)
             {
                 return Ok(new { status = "error", message = "Sorry missing information" });
             }
             var UpdateSchedule = await _customRepo.UpdateCustomAsync(customerScheduleDto);
             if (UpdateSchedule == null)
             {
                 return Ok(new { status = "error", message = "Sorry something wrong" });
             }
             return Ok(new {status ="success",message = "update success"});
             }
             catch (Exception ex)
             {
                 return StatusCode(500, new { status = "error", message = ex.Message });
             }

         }*/
       // [HttpPost("reschedule")]
public async Task<IActionResult> CustomSchedule([FromBody] List<EditCustomSchedule> editCustomSchedules)
{
    try
    {
        if (editCustomSchedules == null || !editCustomSchedules.Any())
        {
            return Ok(new { status = "error", message = "Missing schedule data" });
        }

        foreach (var item in editCustomSchedules)
        {
            var updateResult = await _customRepo.UpdateCustomAsync(item);
            if (updateResult == null)
            {
                return Ok(new { status = "error", message = "Failed to update one or more schedules" });
            }
        }

        return Ok(new { status = "success", message = "All schedules updated successfully" });
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { status = "error", message = ex.Message });
    }
}

    }
}