using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.PayrollHistory;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace backend.Repository
{
    public class PayrollHistoryRepository :IPayrollHistoryRepository
    {
        public readonly ApplicationDbContext _context;
        public PayrollHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PayrollHistory> CreatePayRollAsync(PayrollHistory payrollHistory)
        {
          await _context.PayrollHistories.AddAsync(payrollHistory);
          _context.SaveChangesAsync();
          return payrollHistory;
        }
    }
}