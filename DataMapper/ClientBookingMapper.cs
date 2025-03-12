using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.BookingDto;
using backend.Models;

namespace backend.DataMapper
{
    public static class ClientBookingMapper
    {
        public static ClientBooking ToCreateClientBooking(this ClientBookingDto clientModel){
            return new ClientBooking{
                selectedService = clientModel.SelectedService,
                BookingId = clientModel.BookingId
            };
        }
    }
}