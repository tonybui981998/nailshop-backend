using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataMapper;
using backend.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceController :ControllerBase
    {
        private readonly IServiceRepository _serviceRepo;
        public ServiceController(IServiceRepository serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

    [HttpGet("allservice")]
    public async Task<IActionResult> AllServices(){
        var getService = await _serviceRepo.GetAllService();
        var getAllData = getService.Select(x=>x.GetAllData());
        return Ok(getAllData);
    }
    }
}