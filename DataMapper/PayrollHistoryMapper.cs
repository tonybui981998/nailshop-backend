using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.PayrollHistory;
using backend.Migrations;
using backend.Models;

namespace backend.DataMapper
{
    public static class PayrollHistoryMapper
    {   
        public static PayrollHistory ToCreatePayrollHistory (this PayrollHistoryDto payrollHistoryDto){
            return new PayrollHistory{
                Id = payrollHistoryDto.Id,
                StaffId = payrollHistoryDto.StaffId,
                StartDate = payrollHistoryDto.StartDate,
                EndDate = payrollHistoryDto.EndDate,
                TotalHours = payrollHistoryDto.TotalHours,
                HourlyRate = payrollHistoryDto.HourlyRate,
                TotalPay = payrollHistoryDto.TotalPay,
                IsPaid = payrollHistoryDto.IsPaid
            };
        }
    }
}