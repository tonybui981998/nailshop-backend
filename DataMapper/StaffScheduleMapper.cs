using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto;
using backend.Models;

namespace backend.DataMapper
{
    public static class StaffScheduleMapper
    {
        public static StaffScheduleDto ToAllSchedule(this StaffSchedule staffmodel){
            return new StaffScheduleDto{
                Id = staffmodel.Id,
                StartTime = staffmodel.StartTime,
                EndTime = staffmodel.EndTime,
                DayOfWeek = staffmodel.DayOfWeek
            };
        }
    }
}