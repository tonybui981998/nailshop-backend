using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataMapper;
using backend.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/service-option")]
    public class ServiceOptionsController :ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public ServiceOptionsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("admin-get-color")]
        public async Task<IActionResult> GetColorService(){
            var result = await _context.ServiceOptions.Select(x=>x.GetAdminOptionColor()).ToListAsync();
            if(result == null){
                return Ok(new {status = "error",message = "sorry something wrong"});
            }
           return Ok(result);

        }
    }
}