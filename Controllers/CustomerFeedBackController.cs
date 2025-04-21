using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/feedback")]
    public class CustomerFeedBackController : ControllerBase
    {
        private readonly IFeedBackRepository _feedBackRepo;
        private readonly ApplicationDbContext _context;
        public CustomerFeedBackController(IFeedBackRepository feedBackRepo ,ApplicationDbContext context)
        {
            _feedBackRepo = feedBackRepo;
            _context = context;
        }
        [HttpPost("createfeedback")]
        public async Task<IActionResult> CreateFeedBack([FromBody] CustomerFeedback customerFeedback){
            if (customerFeedback == null || string.IsNullOrEmpty(customerFeedback.FullName) || string.IsNullOrEmpty(customerFeedback.Message))
    {
        return BadRequest(new { status = "error", message = "Invalid feedback data." });
    }

            await _feedBackRepo.CreateFeedBackAsync(customerFeedback);
            return Ok(new { status = "success", message = "Feedback submitted successfully." });
        }
        [HttpGet("allfeedback")]
        public async Task<IActionResult> GetAllFeedBack(){
            var allFeedBack = await _feedBackRepo.GetAllCustomerFeedBackAsync();
          return Ok(allFeedBack);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteFeedBack([FromRoute] int id){
            var result = await _feedBackRepo.DeleteCustomerFeedBack(id);
            if(result == null){
                return Ok(new {status = "error",message = "sorry something wrong"});
            }
            return Ok(new {status = "success",message = "Delete success"});
        }
    }
}