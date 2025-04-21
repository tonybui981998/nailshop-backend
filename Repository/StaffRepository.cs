using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.StaffDto;
using backend.DataMapper;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;
        public StaffRepository(ApplicationDbContext context)
        {
            _context= context;
        }
        public async Task<List<Staff>> AllStaff()
        {
            var staffs = await _context.Staffs.Include(x=>x.StaffSchedules).ToListAsync();
            return  staffs;
        }

        public async Task<List<StaffAdminDto>> GetAllStaffAsync()
        {
          var staff = await _context.Staffs.Include(x=>x.StaffSchedules).Include(u=>u.CustomSchedules).Include(c=>c.Bookings).ThenInclude(d=>d.ClientBookings).ToListAsync();
          var allstaff = staff.Select(x=>x.TogetAllAdminStaff()).ToList();
           return allstaff;
        }

        public Task<bool> StaffExist(int id)
        {
            return _context.Staffs.AnyAsync(x=>x.Id == id);
        }
    }
}