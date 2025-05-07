using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.BookingConfirm;
using backend.Models;

namespace backend.IRepository
{
    public interface  IBookingConfirmRepository
    {
        Task <BookingConfirm> CreateBookingConfirmAsync(BookingConfirm bookingConfirm,List<ConfirmService> confirmServices);
        
    }
}