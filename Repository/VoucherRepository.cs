using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.VoucherDto;
using backend.DataMapper;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace backend.Repository
{
  public class VoucherRepository : IVoucherRepository
  {
    private readonly ApplicationDbContext _context;
    public VoucherRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Voucher> CheckExistAsync(VoucherCheckDto voucherCheckDto)
    {
        var check = await _context.Vouchers.FirstOrDefaultAsync(v=>v.Code ==voucherCheckDto.Code);
     if(check == null){
        return null;
     }
     if(check.IsActive == false){
        return null;
     }
   return check;
    }

    public async Task<Voucher> CheckVoucherAsync(string code,decimal RemainingAmount)
    {
      var checkVoucher = await _context.Vouchers.FirstOrDefaultAsync(x=>x.Code==code);
      if(checkVoucher==null){
        return null;
      }
      checkVoucher.RemainingAmount = RemainingAmount;
      if(RemainingAmount == 0){
        checkVoucher.IsActive = false;
      }
     await _context.SaveChangesAsync();
      return checkVoucher;
    }
  }
}