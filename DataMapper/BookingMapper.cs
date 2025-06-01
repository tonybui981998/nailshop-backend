using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.Bookingdto;
using backend.Models;

namespace backend.DataMapper
{
    public static class BookingMapper
    {
        public static Booking ToCreateBooking(this BookingDto bookingModel){
            return new Booking{
                CustomerName = bookingModel.CustomerName,
                CustomerPhone = bookingModel.CustomerPhone,
                Email = bookingModel.Email,
                BookingDate = bookingModel.BookingDate,
                StartTime = bookingModel.StartTime,
                EndTime = bookingModel.EndTime,
                StaffId = bookingModel.StaffId,
                TotalPrice = bookingModel.TotalPrice,
                BookingNote = bookingModel.BookingNote
                
            };
        }
        public static BookingDto ToGetAllBooking(this Booking bookingModel){
            return new BookingDto{
                Id = bookingModel.Id,
                CustomerName = bookingModel.CustomerName,
               Email = bookingModel.Email,
               CustomerPhone = bookingModel.CustomerPhone,
                BookingDate = bookingModel.BookingDate,
                StartTime = bookingModel.StartTime,
                EndTime = bookingModel.EndTime,
                StaffId = bookingModel.StaffId,
                TotalPrice = bookingModel.TotalPrice,
                BookingNote = bookingModel.BookingNote,
                bookingServices = bookingModel.ClientBookings.Select(x=>x.TogetallService()).ToList()
            };
        }
        public static string ConfirmBookingEmail(BookingDto bookingDto){
            return $@"
             <html>
  <body style='font-family: Arial, sans-serif; background-color: #f5f5f5; padding: 30px;'>
    <div style='max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 10px; box-shadow: 0 4px 12px rgba(0,0,0,0.1);'>

      <!-- Header -->
      <div style='background-color: #e0f7fa; padding: 30px 20px; text-align: center;'>
        <h1 style='margin: 0; font-size: 30px; color: #0097a7;'>AivyBeauty</h1>
        <p style='margin: 5px 0 0; font-size: 15px; color: #555;'>Your booking is confirmed ✨</p>
      </div>

      <!-- Content -->
      <div style='padding: 30px; font-size: 15px; color: #333; line-height: 1.7;'>
        <p>Hi <strong>{bookingDto.CustomerName}</strong>,</p>
        <p>We’re excited to confirm your booking at AivyBeauty!</p>
        <p><strong>Date:</strong> {bookingDto.BookingDate:dddd, dd MMMM yyyy}</p>
        <p><strong>Start Time:</strong> {bookingDto.StartTime}</p>
        <p><strong>Total Price:</strong> ${bookingDto.TotalPrice}</p>
        <p>📍 Please make sure to arrive on time for your appointment. If you are running late, kindly let us know in advance.</p>
        <p>We look forward to seeing you soon!</p>
      </div>

      <!-- Footer -->
      <div style='background-color: #e0f7fa; padding: 15px; text-align: center; font-size: 13px; color: #666;'>
        © {DateTime.Now.Year} AivyBeauty. All rights reserved.
      </div>

    </div>
  </body>
</html>";
        }
      
    }
}