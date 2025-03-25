using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;

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
    }
}