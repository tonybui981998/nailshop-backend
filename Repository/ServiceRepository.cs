using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace backend.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Service>> GetAllService()
        {
         var allService = await _context.Services.Include(x=>x.ServiceOptions).ToListAsync();
         return allService;
        }
    }
}