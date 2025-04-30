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
      
    }
}