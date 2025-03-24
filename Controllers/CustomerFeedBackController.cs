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
    [Route("api/feedback")]
    public class CustomerFeedBackController : ControllerBase
    {
        private readonly IFeedBackRepository _feedBackRepo;
        public CustomerFeedBackController(IFeedBackRepository feedBackRepo)
        {
            _feedBackRepo = feedBackRepo;
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
    }
}