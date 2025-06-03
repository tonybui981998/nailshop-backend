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
    // for create for book next
    public static BookingConfirm TogetConfirmBooking(this BookingConfirmDto bookingConfirmDto)
    {
      return new BookingConfirm
      {
        VoucherAmount = bookingConfirmDto.VoucherAmount,
        VoucherCode = bookingConfirmDto.VoucherCode,
        Discount = bookingConfirmDto.Discount,
        TotalPay = bookingConfirmDto.TotalPay,
        BookingId = bookingConfirmDto.BookingId,
        BookingStatus = bookingConfirmDto.BookingStatus,
        CusName = bookingConfirmDto.CusName,
        CusPhone = bookingConfirmDto.CusPhone,
        BookingDate = bookingConfirmDto.BookingDate,
        StartTime = bookingConfirmDto.StartTime,
        EndTime = bookingConfirmDto.EndTime,
        // ConfirmServices = bookingConfirmDto.Service.Select(s=>s.TogetConfirmService()).ToList()
      };
    }
    // get confirmbooking
    public static BookingcheckConfirmDto ToGetAllConfirmBooking(this BookingConfirm bookingConfirm)
    {
      return new BookingcheckConfirmDto
      {
        VoucherAmount = bookingConfirm.VoucherAmount,
        VoucherCode = bookingConfirm.VoucherCode,
        BookingStatus = bookingConfirm.BookingStatus,
        Discount = bookingConfirm.Discount,
        TotalPay = bookingConfirm.TotalPay,
        BookingId = bookingConfirm.BookingId,
        CusName = bookingConfirm.CusName,
        CusPhone = bookingConfirm.CusPhone,
        BookingDate = bookingConfirm.BookingDate,
        StartTime = bookingConfirm.StartTime,
        EndTime = bookingConfirm.EndTime,
        Service = bookingConfirm.ConfirmServices.Select(x => x.TogetAllConfirmService()).ToList()

      };
    }
    public static string SendBillConfirm(string CusName, decimal TotalPay)
    {
      return $@"
<html>
  <body style='font-family: Arial, sans-serif; background-color: #f5f5f5; padding: 30px;'>
    <div style='max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 10px; box-shadow: 0 4px 12px rgba(0,0,0,0.1);'>

      <!-- Header -->
      <div style='background-color: #e3f2fd; padding: 30px 20px; text-align: center;'>
        <h1 style='margin: 0; font-size: 28px; color: #1976d2;'>AivyBeauty</h1>
        <p style='margin: 5px 0 0; font-size: 14px; color: #666;'>Thank you for your payment 💖</p>
      </div>

      <!-- Content -->
      <div style='padding: 30px; font-size: 15px; color: #333; line-height: 1.7;'>
        <p>Hi <strong>{CusName}</strong>,</p>
        <p>We’ve received your payment successfully.</p>
        <p><strong>Total Amount Paid:</strong> ${TotalPay}</p>
        <p>Thank you for your trust. We can’t wait to serve you again soon!</p>
      </div>

      <!-- Footer -->
      <div style='background-color: #e3f2fd; padding: 15px; text-align: center; font-size: 13px; color: #666;'>
        © {DateTime.Now.Year} AivyBeauty. All rights reserved.
      </div>

    </div>
  </body>
</html>";
    }
public static string SendNoShowNotice(string CusName)
{
    return $@"
<html>
  <body style='font-family: Arial, sans-serif; background-color: #f5f5f5; padding: 30px;'>
    <div style='max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 10px; box-shadow: 0 4px 12px rgba(0,0,0,0.1);'>

      <!-- Header -->
      <div style='background-color: #ffe0b2; padding: 30px 20px; text-align: center;'>
        <h1 style='margin: 0; font-size: 28px; color: #ef6c00;'>AivyBeauty</h1>
        <p style='margin: 5px 0 0; font-size: 14px; color: #666;'>Missed Appointment Notice</p>
      </div>

      <!-- Content -->
      <div style='padding: 30px; font-size: 15px; color: #333; line-height: 1.7;'>
        <p>Hi <strong>{CusName}</strong>,</p>
        <p>We noticed that you were unable to attend your scheduled appointment. We hope everything is okay!</p>
        <p>If you need to reschedule, please don’t hesitate to contact us. We're always happy to assist you.</p>
        <p>Thank you for choosing AivyBeauty, and we look forward to seeing you soon 💖</p>
      </div>

      <!-- Footer -->
      <div style='background-color: #ffe0b2; padding: 15px; text-align: center; font-size: 13px; color: #666;'>
        © {DateTime.Now.Year} AivyBeauty. All rights reserved.
      </div>

    </div>
  </body>
</html>";
}


  }
}