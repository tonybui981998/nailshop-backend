using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.CustomScheduleDto;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
  public class CustomScheduleRepository : ICustomScheduleRepository
  {
        private readonly ApplicationDbContext _context;

        public CustomScheduleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    public async Task<CustomSchedule> UpdateCustomAsync(EditCustomSchedule editCustomSchedule)
        {
            var checkExist = await _context.CustomSchedules.FirstOrDefaultAsync(s=>s.Date == editCustomSchedule.Date && s.StaffId == editCustomSchedule.StaffId);
            if (checkExist != null)
            {
                checkExist.Date = editCustomSchedule.Date;
                checkExist.StartTime = editCustomSchedule.StartTime;
                checkExist.EndTime = editCustomSchedule.EndTime;
                checkExist.IsDayOff = editCustomSchedule.IsDayOff;
           }
            if (checkExist == null)
            {
                var createNewSchedule = new CustomSchedule
                {
                    Date = editCustomSchedule.Date,
                    StartTime = editCustomSchedule.StartTime,
                    EndTime = editCustomSchedule.EndTime,
                 IsDayOff = editCustomSchedule.IsDayOff,
                    StaffId = editCustomSchedule.StaffId
                };
                _context.CustomSchedules.Add(createNewSchedule);
               
                checkExist = createNewSchedule;
            }


    await _context.SaveChangesAsync();




            return checkExist;
        }
  }
}