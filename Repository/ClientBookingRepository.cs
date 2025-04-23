using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.Bookingdto;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class ClientBookingRepository : IClientBookingRepository
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly ApplicationDbContext _context;
        public ClientBookingRepository(ApplicationDbContext context,IBookingRepository bookingRepo)
        {
            _context = context;
            _bookingRepo = bookingRepo;
        }

    public async Task<ClientBooking> DeleteServiceAsync(ClientDeleteServiceDto clientDeleteServiceDto)
    {
    var checkBooking = await _bookingRepo.IDExistAsync(clientDeleteServiceDto.BookingId);
        if(checkBooking == null){
            return null;
        }
        var checkService = await _context.ClientBookings.FirstOrDefaultAsync(s=>s.BookingId == clientDeleteServiceDto.BookingId && s.selectedService == clientDeleteServiceDto.selectedService);
        if(checkService == null){
            return null;
        }
        _context.ClientBookings.Remove(checkService);
        await _context.SaveChangesAsync();
          var checkBookingIdExist = await _context.ClientBookings.Where(x=>x.BookingId == clientDeleteServiceDto.BookingId).ToListAsync();
      if(checkBookingIdExist.Count == 0){
        var GetBookingId = await _context.Bookings.FindAsync(clientDeleteServiceDto.BookingId);
        if(GetBookingId == null){
            return null;
        }
        _context.Bookings.Remove(GetBookingId);
        await _context.SaveChangesAsync();
      }
        return checkService;
    }
  }
}