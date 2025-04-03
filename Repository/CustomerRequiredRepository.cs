using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.CustomerRequireddto;
using backend.DataMapper;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace backend.Properties
{
    public class CustomerRequiredRepository : ICustomerRequiredRepository
    {
        public readonly ApplicationDbContext _context;
        public CustomerRequiredRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CustomerRequired> CreateRequireAsync(CustomerRequired customerRequired)
        {
            await _context.CustomerRequireds.AddAsync(customerRequired);
            await _context.SaveChangesAsync();
            return customerRequired;
        }

        public async Task<CustomerRequired> DeleteRequiredAsync(int id)
        {
            var checkId = await _context.CustomerRequireds.FindAsync(id);
            if(checkId == null){
                return null;
            }
           _context.CustomerRequireds.Remove(checkId);
           await _context.SaveChangesAsync();
           return checkId;
        }

        public async Task<List<CustomerRequiredDto>> GetAllRequiredAsync()
        {
          return await  _context.CustomerRequireds.Select(x=>x.TogetallRequired()).ToListAsync();

        }
    }
}