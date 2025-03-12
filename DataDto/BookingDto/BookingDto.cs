using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.DataDto.BookingDto
{
    public class BookingDto
    {
           
        public int Id {get;set;}

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerPhone {get;set;}
         [Required]
        public string Email { get; set; }

        public DateTime BookingDate {get;set;}

        [Required]
        public TimeSpan StartTime {get;set;}
         public decimal TotalPrice { get; set; } 

        [Required]

        public TimeSpan EndTime {get;set;}

        public DateTime CreateAt {get;set;} = DateTime.UtcNow;

        public int StaffId {get;set;}

    public List<ClientBookingDto> bookingServices {get;set;} = new List<ClientBookingDto>();


    }
}