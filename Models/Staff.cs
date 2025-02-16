using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
      

        public bool IsActive { get; set; }
          [Required]
        public string AvatarUrl { get; set; } = "default-avatar.png";

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

     public   List<StaffSchedule> StaffSchedules {get;set;} = new List<StaffSchedule>();
        public List<Booking> Bookings {get;set;} = new List<Booking>();

    }
}