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
            _context = context;
        }
        public async Task<List<Staff>> AllStaff()
        {
            var staffs = await _context.Staffs.Include(x=>x.StaffSchedules).ToListAsync();
            return  staffs;
        }

        public async Task<Staff> CreateStaffAsync(AddNewStaffDto addNewStaffDto)
        {
            var createStaff = addNewStaffDto.ToCreateStaff();
            _context.Staffs.Add(createStaff);
            await _context.SaveChangesAsync();
            return createStaff;
            
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

        public async Task<Staff> UpdateStaffAsync(EditStaffInforDto editStaffInforDto)
        {
            var checkStaffExist = await _context.Staffs.FirstOrDefaultAsync(x => x.Id == editStaffInforDto.StaffId);
            if (checkStaffExist == null)
            {
                return null;
            }
            if (checkStaffExist != null)
            {
                checkStaffExist.FullName = editStaffInforDto.FullName;
                checkStaffExist.PhoneNumber = editStaffInforDto.PhoneNumber;
                checkStaffExist.IsActive = editStaffInforDto.IsActive;
            }
            var currentSchedule = await _context.StaffSchedules.Where(s =>s.StaffId == editStaffInforDto.StaffId).ToListAsync();
            var newSchedule = editStaffInforDto.EditStaffScheduleDtos;

            foreach (var schedule in currentSchedule)
            {
                var matchData = newSchedule.FirstOrDefault(x => x.DayOfWeek == schedule.DayOfWeek);
                if (matchData == null)
                {
                    _context.StaffSchedules.Remove(schedule);
                }
                if (matchData != null)
                {
                    schedule.StartTime = matchData.StartTime;
                    schedule.EndTime = matchData.EndTime;
                }
            }
            foreach (var schedule in newSchedule)
            {
                var matchData = currentSchedule.FirstOrDefault(x => x.DayOfWeek == schedule.DayOfWeek);
                if (matchData == null)
                {
                    var newstaffSchedule = new StaffSchedule
                    {
                        StartTime = schedule.StartTime,
                        EndTime = schedule.EndTime,
                        StaffId = editStaffInforDto.StaffId,
                        DayOfWeek = schedule.DayOfWeek
                    };
                     _context.StaffSchedules.Add(newstaffSchedule);
                }
            }
           await _context.SaveChangesAsync();
            return checkStaffExist;
    }
  }
}