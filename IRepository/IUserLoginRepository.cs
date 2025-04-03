using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.LoginDto;
using backend.Models;

namespace backend.IRepository
{
    public interface IUserLoginRepository
    {
        Task<UserAccount>LoginUser(LoginDto loginDto);
    }
}