using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;

namespace backend.Repository
{
    public class FeedBackRepository : IFeedBackRepository
    {
        public readonly ApplicationDbContext _context;
        public FeedBackRepository(ApplicationDbContext context)
        {
            _context = context;            
        }
        public async Task<CustomerFeedback> CreateFeedBackAsync(CustomerFeedback customerFeedback)
        {
             await _context.CustomerFeedbacks.AddAsync(customerFeedback);
             await _context.SaveChangesAsync();
             return customerFeedback;
        }
    }
}