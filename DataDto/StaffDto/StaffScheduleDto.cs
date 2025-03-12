using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto
{
    public class StaffScheduleDto
    {
          public int Id { get; set; }
    
        public string DayOfWeek { get; set; } 

       
        public TimeSpan StartTime {get;set;}

    
        public TimeSpan EndTime {get;set;}

        public int StaffId {get;set;}
    }
}