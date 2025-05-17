using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.BookingConfirm;
using backend.Models;

namespace backend.DataMapper
{
    public static class ConfirmBookingMapper
    {
        // for create
        public static BookingConfirm TogetConfirmBooking (this BookingConfirmDto bookingConfirmDto){
            return new BookingConfirm {
                VoucherAmount = bookingConfirmDto.VoucherAmount,
                VoucherCode = bookingConfirmDto.VoucherCode,
                Discount = bookingConfirmDto.Discount,
                TotalPay = bookingConfirmDto.TotalPay,
                BookingId = bookingConfirmDto.BookingId,
                BookingStatus = bookingConfirmDto.BookingStatus,
                CusName = bookingConfirmDto.CusName,
                CusPhone = bookingConfirmDto.CusPhone,
                ConfirmServices = bookingConfirmDto.Service.Select(s=>s.TogetConfirmService()).ToList()
            };
        }
        // get confirmbooking
    public static BookingcheckConfirmDto ToGetAllConfirmBooking (this BookingConfirm bookingConfirm){
        return new BookingcheckConfirmDto {
            VoucherAmount = bookingConfirm.VoucherAmount,
            VoucherCode = bookingConfirm.VoucherCode,
            BookingStatus = bookingConfirm.BookingStatus,
            Discount = bookingConfirm.Discount,
            TotalPay = bookingConfirm.TotalPay,
            BookingId = bookingConfirm.BookingId,
            CusName = bookingConfirm.CusName,
            CusPhone = bookingConfirm.CusPhone,
            Service = bookingConfirm.ConfirmServices.Select(x=>x.TogetAllConfirmService()).ToList()
          
        };
    }
    }
}