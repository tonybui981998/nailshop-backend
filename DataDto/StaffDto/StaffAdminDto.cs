using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.Bookingdto;
using backend.DataDto.CustomScheduleDto;
using backend.Models;

namespace backend.DataDto.StaffDto
{
    public class StaffAdminDto
    {
           public int Id { get; set; }
   
        public string FullName { get; set; }

 
        public string PhoneNumber { get; set; }
      

        public string IsActive { get; set; }
          public List<StaffScheduleDto> StaffScheduleDtos {get;set;} = new List<StaffScheduleDto>();
          public List<CustomerScheduleDto> CustomerScheduleDtos {get;set;} = new List<CustomerScheduleDto>();

         public List<BookingDto> BookingDtos {get;set;} = new List<BookingDto>();
          
    }
}