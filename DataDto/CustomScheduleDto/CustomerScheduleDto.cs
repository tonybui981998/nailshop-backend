using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto.CustomScheduleDto
{
    public class CustomerScheduleDto
    {
    public int Id { get; set; }

    public DateTime Date { get; set; } 

    public TimeSpan? StartTime { get; set; } 

    public TimeSpan? EndTime { get; set; }

    public bool IsDayOff { get; set; } = false; 

    public int StaffId { get; set; }
   
    }
}