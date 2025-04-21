using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.DataDto.PayrollHistory
{
    public class PayrollHistoryGetAllDto
    {
      public int  StaffId {get;set;}
      public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public double TotalHours { get; set; }
    public decimal HourlyRate { get; set; }
    public decimal TotalPay { get; set; }
    }
}