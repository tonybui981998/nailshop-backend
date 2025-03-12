using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> getAllStaff(){
            var staffss = await _staffRepo.AllStaff();
            var staffData =  staffss.Select(x=>x.ToAllStaff());
            return Ok(staffData);
        }
    }
}