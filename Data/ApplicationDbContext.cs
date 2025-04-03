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

        public DbSet<Staff> Staffs {get;set;}

        public DbSet<StaffSchedule> StaffSchedules {get;set;}

        public DbSet<Booking> Bookings {get;set;}

      public DbSet<ClientBooking> ClientBookings { get; set; }
      public DbSet<CustomerFeedback> CustomerFeedbacks {get;set;}

      public DbSet<CustomerRequired> CustomerRequireds {get;set;}

      public DbSet<UserAccount> UserAccounts {get;set;}


      


        
    }
}