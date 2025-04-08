using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.CustomScheduleDto;
using backend.Models;

namespace backend.DataMapper
{
    public static class CustomerScheduleMapper
    {
        public static CustomerScheduleDto TogetallCustomSchedule (this CustomSchedule customSchedule){
            return new CustomerScheduleDto{
                Id = customSchedule.Id,
                Date = customSchedule.Date,
                StartTime = customSchedule.StartTime,
                EndTime = customSchedule.EndTime,
                IsDayOff = customSchedule.IsDayOff, 
               StaffId = customSchedule.StaffId,

            };
        }
    }
}