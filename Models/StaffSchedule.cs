using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class StaffSchedule
    {
        [Key]
        public int Id { get; set; }
    [Required]
        public string DayOfWeek { get; set; } 

        [Required]
        public TimeSpan StartTime {get;set;}

        [Required]
        public TimeSpan EndTime {get;set;}

        public int StaffId {get;set;}
          [ForeignKey("StaffId")]
        public Staff Staff {get;set;}
    }
}