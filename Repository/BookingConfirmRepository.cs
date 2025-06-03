using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using backend.DataDto.BookingConfirm;
using backend.DataMapper;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
  public class BookingConfirmRepository : IBookingConfirmRepository
  {
    public readonly ApplicationDbContext _context;
    public BookingConfirmRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BookingConfirm> CheckExistAsync(int id)
    {
      var checkId = await _context.BookingConfirms.FirstOrDefaultAsync(x=>x.BookingId == id);
      if(checkId == null){
        return null;
      }else{
        return checkId;
      }
    }

    public async Task<BookingConfirm> CreateBookingConfirmAsync(BookingConfirm  bookingConfirm, List<ConfirmService> confirmServices)
    {
      await _context.BookingConfirms.AddAsync(bookingConfirm);
      await _context.SaveChangesAsync();

      foreach(var item in confirmServices){
        item.BookingConfirmId = bookingConfirm.Id;
      }
      await _context.ConfirmServices.AddRangeAsync(confirmServices);
      await _context.SaveChangesAsync();
      return bookingConfirm;

    }

    public async Task<List<BookingcheckConfirmDto>> GetAllBookingConfirmAsync()
    {
 var result = await _context.BookingConfirms.Include(x=>x.ConfirmServices).Select(x=>x.ToGetAllConfirmBooking()).ToListAsync();
  return result;
    }

    public Task SenBillConfirm(string CusName, decimal TotalPay,string email)
    {
      var fromEmail = "anhbui981998@gmail.com";
      var emailPassword = "suyb nntx krxr qeou";
      var smtpClient = new SmtpClient("smtp.gmail.com"){
        Port = 587,
        Credentials = new NetworkCredential(fromEmail,emailPassword),
        EnableSsl = true
      };
      var htmlBody = ConfirmBookingMapper.SendBillConfirm(CusName,TotalPay);
      var mailMessage = new MailMessage{
        From = new MailAddress(fromEmail),
        Subject = "Message from love nails Aivy beauty",
        Body = htmlBody,
        IsBodyHtml = true
      } ;
      mailMessage.To.Add(email);
      try{
        smtpClient.Send(mailMessage);
        return Task.CompletedTask;
       
      }catch(Exception ex){
        throw new Exception ("Sorry something wrong , please try again");
      }
    }

    public Task SendDidnotComeNotice(string name,string email)
    {
      var fromEmail = "anhbui981998@gmail.com";
      var emailPassword = "suyb nntx krxr qeou";
      var smtpClient = new SmtpClient("smtp.gmail.com"){
        Port = 587,
        Credentials = new NetworkCredential(fromEmail,emailPassword),
        EnableSsl = true
      };
      var htmlBody = ConfirmBookingMapper.SendNoShowNotice(name);
      var mailMessage = new MailMessage{
        From = new MailAddress(fromEmail),
        Subject = "Message from love nails Aivy beauty",
        Body = htmlBody,
        IsBodyHtml = true
      } ;
      mailMessage.To.Add(email);
      try{
        smtpClient.Send(mailMessage);
        return Task.CompletedTask;
       
      }catch(Exception ex){
        throw new Exception ("Sorry something wrong , please try again");
      }
    }
  }
}