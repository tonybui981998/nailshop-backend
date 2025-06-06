using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.BookingConfirm;
using backend.Models;

namespace backend.IRepository
{
    public interface IBookingConfirmRepository
    {
        Task<BookingConfirm> CreateBookingConfirmAsync(BookingConfirm bookingConfirm, List<ConfirmService> confirmServices);
        Task<BookingConfirm> CheckExistAsync(int id);

        Task<List<BookingcheckConfirmDto>> GetAllBookingConfirmAsync();

        Task SenBillConfirm(string CusName, decimal TotalPay ,string email);

        Task SendDidnotComeNotice(string name , string email);
        
    }
}