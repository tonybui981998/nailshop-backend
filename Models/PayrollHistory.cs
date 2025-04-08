using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class PayrollHistory
    {
        [Key]
    public int Id { get; set; }

    public int StaffId { get; set; }
    [ForeignKey("StaffId")]
    public Staff Staff { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public double TotalHours { get; set; }
    public decimal HourlyRate { get; set; }
    public decimal TotalPay { get; set; }

    public bool IsPaid { get; set; } = false;      
    public DateTime? PaidAt { get; set; }          

    public DateTime CalculatedAt { get; set; } = DateTime.Now;
    }
}