using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class CustomSchedule
    {
           [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; } 

    public TimeSpan? StartTime { get; set; } 

    public TimeSpan? EndTime { get; set; }

    public bool IsDayOff { get; set; } = false; 

    [ForeignKey("Staff")]
    public int StaffId { get; set; }
    public Staff Staff { get; set; }
    }
}