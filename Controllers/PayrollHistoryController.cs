using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.PayrollHistory;
using backend.DataMapper;
using backend.IRepository;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/payroll")]
    public class PayrollHistoryController :ControllerBase
    {
        private readonly IPayrollHistoryRepository _payrollRepo;
        private readonly IStaffRepository _staffRepo;
        public PayrollHistoryController(IPayrollHistoryRepository payrollRepo, IStaffRepository staffRepo)
        {
            _payrollRepo = payrollRepo;
            _staffRepo = staffRepo;
        }

        [HttpGet("payment-history")]
        public async Task<IActionResult> GetAllhistorypay(){
            var alldata = await _payrollRepo.GetAllPayrollHistoryAsync();
            if(alldata == null){
                return Ok(new {status ="error",message ="sorry something went wrong"});
            }
           var dataDto = alldata.Select(x=>x.TogetAllPayrollHistory()).ToList();
           if(dataDto == null){
            return Ok(new {status = "error",message ="sorry no data found"});
           }
            return Ok(dataDto);
        }

        [HttpPost("create-payroll")]
        public async Task<IActionResult>CreatePayroll([FromBody] PayrollHistoryDto payrollHistoryDto){
            if(payrollHistoryDto == null){
                return Ok(new {status ="error",message = "sorry missing information"});
            }
            var checkStaff = await _staffRepo.StaffExist(payrollHistoryDto.StaffId);
            if(!checkStaff){
                return Ok(new {status ="error",message = "sorry something wrong"});
            }

            var payroll =  payrollHistoryDto.ToCreatePayrollHistory();
            await _payrollRepo.CreatePayRollAsync(payroll);
            return Ok(new{status = "success",message ="create success"});
        }
    }
}