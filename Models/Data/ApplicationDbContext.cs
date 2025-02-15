using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }
       public DbSet<Service> Services {get;set;}
        public DbSet<ServiceOptions> ServiceOptions {get;set;}
        
    }
}