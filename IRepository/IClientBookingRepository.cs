using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.Bookingdto;
using backend.Models;

namespace backend.IRepository
{
    public interface IClientBookingRepository
    {
        Task<ClientBooking>DeleteServiceAsync(ClientDeleteServiceDto clientDeleteServiceDto);
    }
}