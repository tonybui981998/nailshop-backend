using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.PayrollHistory;
using backend.Models;

namespace backend.IRepository
{
    public interface IPayrollHistoryRepository
    {
        Task<PayrollHistory> CreatePayRollAsync( PayrollHistory payrollHistory);
    }
}