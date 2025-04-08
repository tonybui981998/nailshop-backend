using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto.PayrollHistory
{
    public class PayrollHistoryDto
    {
        
    public int Id { get; set; }

    public int StaffId { get; set; }
  
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public double TotalHours { get; set; }
    public decimal HourlyRate { get; set; }
    public decimal TotalPay { get; set; }

    public bool IsPaid { get; set; } = false;      
    public DateTime? PaidAt { get; set; }          


    }
}