using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.DataDto.Bookingdto
{
    public class BookingDto
    {
           
        public int Id {get;set;}

     
        public string CustomerName { get; set; }

   
        public string CustomerPhone {get;set;}
     
        public string Email { get; set; }

        public DateTime BookingDate {get;set;}

        
        public TimeSpan StartTime {get;set;}
         public decimal TotalPrice { get; set; } 

           public string? BookingNote { get; set; }

        public TimeSpan EndTime {get;set;}

      

        public int StaffId {get;set;}

    public List<ClientBookingDto> bookingServices {get;set;} = new List<ClientBookingDto>();
    


    }
}