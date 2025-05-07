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
        public static BookingConfirm TogetConfirmBooking (this BookingConfirmDto bookingConfirmDto){
            return new BookingConfirm {
                VoucherAmount = bookingConfirmDto.VoucherAmount,
                VoucherCode = bookingConfirmDto.VoucherCode,
                Discount = bookingConfirmDto.Discount,
                TotalPay = bookingConfirmDto.TotalPay,
                BookingId = bookingConfirmDto.BookingId,
                BookingStatus = bookingConfirmDto.BookingStatus,
                ConfirmServices = bookingConfirmDto.Service.Select(s=>s.TogetConfirmService()).ToList()
            };
        }
    }
}