using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.LoginDto;
using backend.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserLoginController :ControllerBase
    {
        private readonly IUserLoginRepository _userRepo;
        public UserLoginController(IUserLoginRepository userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto loginDto){
            if(loginDto == null || string.IsNullOrEmpty(loginDto.UserName) || string.IsNullOrEmpty(loginDto.Password) ){
                return Ok(new {status = "error",message = "Sorry something wrong"});
            }
            var user = await _userRepo.LoginUser(loginDto);
            if(user == null){
                return Ok(new {status = "error",message = "sorry user do not exist"});
            }else{
                return Ok(new {status = "success",message = "login success", data = new {
                    UserName = user.UserName,
                    Role = user.Role
                }});
            }


        }
    }
}