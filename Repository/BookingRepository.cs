using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using backend.DataDto.Bookingdto;
using backend.DataMapper;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Booking> CreateBookingAsync(Booking booking, List<ClientBooking> clientBookings)
        {
          await  _context.Bookings.AddAsync(booking);
          await  _context.SaveChangesAsync();

          foreach(var item in clientBookings){
            item.BookingId =  booking.Id;
          }
        await  _context.ClientBookings.AddRangeAsync(clientBookings);
            await _context.SaveChangesAsync();

            return booking;
        }

    public async Task<Booking> DeleteBookingAsync(int id)
    {
    var  checkId = await _context.Bookings.Include(b=>b.ClientBookings).Include(d=>d.Staff) .FirstOrDefaultAsync(c=>c.Id == id);
      if(checkId == null){
        return null;
      }
    _context.Bookings.Remove(checkId);
    await _context.SaveChangesAsync();
    return checkId;
    }

    public async Task<List<BookingDto>> GetBookingTime()
        {
           var allBooking = await _context.Bookings.Select(x=>x.ToGetAllBooking()).ToListAsync();
           return allBooking;
        }

    public async Task<Booking> IDExistAsync(int id)
    {
      if(id == null){
        return null;
      }
      var result = await _context.Bookings.FindAsync(id);
      if(result == null){
        return null;
      }
      return result;
    }

    public Task SendEmailAsync(BookingDto bookingDto)
    {
     var fromEmail = "anhbui981998@gmail.com";
     var emailPassword = "suyb nntx krxr qeou";
     var smtpClient = new SmtpClient("smtp.gmail.com"){
      Port = 587,
      Credentials = new NetworkCredential(fromEmail,emailPassword),
      EnableSsl = true
     };
     var htmlBody = BookingMapper.ConfirmBookingEmail(bookingDto);
     var mailMessage = new MailMessage{
      From = new MailAddress(fromEmail),
      Subject = "Message from love nauls Aivy beauty",
      Body = htmlBody,
      IsBodyHtml = true
     };
     mailMessage.To.Add(bookingDto.Email);
     try{
      smtpClient.Send(mailMessage);
      return Task.CompletedTask;
     }catch(Exception ex){
      throw new Exception ("Send email failed , please try again later");
     }
  
    }

    public async Task<Booking> UpdateBooking( ClientUpdateDto clientUpdateDto)
    {
      var checkId = await _context.Bookings.FindAsync(clientUpdateDto.Id);
      if(checkId == null){
        return null;
      }
    checkId.CustomerName = clientUpdateDto.CustomerName;
    checkId.CustomerPhone = clientUpdateDto.CustomerPhone;
    checkId.Email = clientUpdateDto.Email;
    await _context.SaveChangesAsync();
    return checkId;

    }
  }
}