using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.BookingDto;
using backend.DataMapper;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;
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

        public async Task<List<BookingDto>> GetBookingTime()
        {
           var allBooking = await _context.Bookings.Select(x=>x.ToGetAllBooking()).ToListAsync();
           return allBooking;
        }
    }
}