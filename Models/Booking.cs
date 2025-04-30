using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Booking
    {
        [Key]
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

        [Required]

        public TimeSpan EndTime {get;set;}
          [Required] 
        public decimal TotalPrice { get; set; }
        
        public string? BookingNote { get; set; }


        public DateTime CreateAt {get;set;} = DateTime.UtcNow;

        public int StaffId {get;set;}

          [ForeignKey("StaffId")]
        public Staff Staff {get;set;}

        public List<ClientBooking> ClientBookings {get;set;} = new List<ClientBooking>();


    }
}