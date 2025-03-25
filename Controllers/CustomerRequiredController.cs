using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.IRepository;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{ 
    [ApiController]
    [Route("api/Required")]
    public class CustomerRequiredController :ControllerBase
    {
        private readonly ICustomerRequiredRepository _requiredRepo;
        public CustomerRequiredController(ICustomerRequiredRepository requiredRepo)
        {
            _requiredRepo = requiredRepo;
        }
        [HttpPost("create-required")]
     public async Task<IActionResult> CreateRequired (CustomerRequired customerRequired){
        if(customerRequired == null){
            return BadRequest(new {status = "error",message ="Sorry something wrong"});
        }
        await _requiredRepo.CreateRequireAsync(customerRequired);
        return Ok(new {status ="success",message="Thank you for your inquiry"});
     }
    }
}