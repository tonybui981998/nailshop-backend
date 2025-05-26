using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using backend.DataDto.VoucherDto;
using backend.DataMapper;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

    public async Task<Voucher> CheckVoucherAutoAsync(string code)
    {
      var checkVOucher = await _context.Vouchers.FirstOrDefaultAsync(x=>x.Code == code);
      if(checkVOucher == null){
        return null;
      }
      
      return checkVOucher;
    }

    public  Task<string> GenerateCodeAsync(int length = 8)
    {
      string character = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      Random random = new Random();
      string code ="";
      for(int i=0 ;i <length;i++){
        int index =  random.Next(character.Length);
        code +=character[index];
      }
     return Task.FromResult(code);
    }

    public async Task<Voucher> GetAuoGenetaCodeAsync(GetVoucherCodeDto getVoucherCodeDto)
    {
      int maxattempt = 11;
      int attempt = 0;
      while(attempt < maxattempt){
        var getCode = await GenerateCodeAsync();
        if(getCode == null){
          throw new Exception("Sorry generate code failed");
        }
        var checkExist = await CheckVoucherAutoAsync(getCode);
        if(checkExist == null){
          var createVoucher =  getVoucherCodeDto.ToSaveVoucher(getCode);
         await _context.Vouchers.AddAsync(createVoucher);
         return createVoucher;
        }
             attempt ++;
      }
      throw new Exception ("Please double check db before contine");
  }

    public Task SendEmailAsync(GetVoucherCodeDto getVoucherCodeDto,string code)
    {
      var fromEmail = "anhbui981998@gmail.com";
      var emailPassword = "suyb nntx krxr qeou";
      var smtpClient = new SmtpClient("smtp.gmail.com"){
        Port = 587,
        Credentials = new NetworkCredential(fromEmail,emailPassword),
        EnableSsl = true
      };
      var htmlBody = VoucherMapper.ConfirmVoucherEmail(getVoucherCodeDto,code);
      var mailMessage = new MailMessage{
        From = new MailAddress(fromEmail),
        Subject = "Message from love nails Aivy beauty",
        Body = htmlBody,
        IsBodyHtml = true
      } ;
      mailMessage.To.Add(getVoucherCodeDto.Email);
      try{
        smtpClient.Send(mailMessage);
        return Task.CompletedTask;
       
      }catch(Exception ex){
        throw new Exception ("Sorry something wrong , please try again");
      }
    }
  }
}