using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.StaffDto;
using backend.DataMapper;
using backend.IRepository;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/staff")]
    public class StaffController : ControllerBase
    {
        public readonly IStaffRepository _staffRepo;
        public StaffController(IStaffRepository staffRepo)
        {
            _staffRepo = staffRepo;
        }
        [HttpGet("allstaff")]
        public async Task<IActionResult> getAllStaff()
        {
            var staffss = await _staffRepo.AllStaff();
            var staffData = staffss.Select(x => x.ToAllStaff());
            return Ok(staffData);
        }
        [HttpGet("admin-allstaff")]
        public async Task<IActionResult> getAllAdminStaff()
        {
            var staff = await _staffRepo.GetAllStaffAsync();
            if (staff == null)
            {
                return Ok(new { status = "error", message = "sorry something wrong" });
            }
            return Ok(staff);
        }
        [HttpPost("create-newStaff")]
        public async Task<IActionResult> CreateStaff([FromBody] AddNewStaffDto addNewStaffDto)
        {
            var newStaff = await _staffRepo.CreateStaffAsync(addNewStaffDto);
            if (newStaff == null)
            {
                return Ok(new { status = "error", message = "Sorry something wrong" });
            }
            return Ok(new { status = "success", message = "create success" });
        }
        [HttpPost("update-staff")]
        public async Task<IActionResult> UpdateStaffDetails([FromBody] EditStaffInforDto editStaffInforDto)
        {
            try
            {
                if (editStaffInforDto == null)
                {
                    return Ok(new { status = "error", message = "Sorry missing information" });
                }
                var updateStaff = await _staffRepo.UpdateStaffAsync(editStaffInforDto);
                if (updateStaff == null)
                {
                    return Ok(new { status = "error", message = "Sorry some thing went wrong" });
                }
                return Ok(new { status = "success", message = "update success" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { status = "error", message = e.Message });
            }
        }
      
    }
}