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
                StaffId = payrollHistoryDto.StaffId,
                StartDate = payrollHistoryDto.StartDate,
                EndDate = payrollHistoryDto.EndDate,
                TotalHours = payrollHistoryDto.TotalHours,
                HourlyRate = payrollHistoryDto.HourlyRate,
                TotalPay = payrollHistoryDto.TotalPay,
                IsPaid = payrollHistoryDto.IsPaid
            };
            
        }
        public static PayrollHistoryGetAllDto TogetAllPayrollHistory (this PayrollHistory payrollHistory){
            return new PayrollHistoryGetAllDto{
                StaffId = payrollHistory.StaffId,
                StartDate = payrollHistory.StartDate,
                EndDate = payrollHistory.EndDate,
                TotalHours = payrollHistory.TotalHours,
                HourlyRate = payrollHistory.HourlyRate,
                TotalPay = payrollHistory.TotalPay
            };
        }
    }
}