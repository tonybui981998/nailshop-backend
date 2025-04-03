using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.LoginDto;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly ApplicationDbContext _context;
        public UserLoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserAccount> LoginUser(LoginDto loginDto)
        {
      

            return await _context.UserAccounts.FirstOrDefaultAsync(x=>x.UserName == loginDto.UserName && x.Password == loginDto.Password);
          
           
        }
    }
}