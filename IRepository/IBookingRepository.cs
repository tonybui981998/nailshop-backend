using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.Bookingdto;
using backend.Models;

namespace backend.IRepository
{
    public interface IBookingRepository
    {
        Task<Booking>CreateBookingAsync(Booking booking ,List<ClientBooking> clientBookings);
        Task<List<BookingDto>>GetBookingTime();
        Task<Booking>DeleteBookingAsync(int id);

        Task<Booking>IDExistAsync(int id);
    }
}