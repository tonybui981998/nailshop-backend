using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto.StaffDto
{
    public class StaffDto
    {
         public int Id { get; set; }
 
        public string FullName { get; set; }

       
       // public string PhoneNumber { get; set; }
      

        public string IsActive { get; set; }
    
        public string Image { get; set; } 

        public List<StaffScheduleDto> StaffScheduleDtos { get; set; } 

        
    }
}