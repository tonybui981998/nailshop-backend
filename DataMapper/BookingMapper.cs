using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.BookingDto;
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
                TotalPrice = bookingModel.TotalPrice
                
            };
        }
        public static BookingDto ToGetAllBooking(this Booking bookingModel){
            return new BookingDto{
               
                BookingDate = bookingModel.BookingDate,
                StartTime = bookingModel.StartTime,
                EndTime = bookingModel.EndTime,
                StaffId = bookingModel.StaffId,
            
            };
        }
    }
}