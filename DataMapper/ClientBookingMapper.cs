using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.Bookingdto;
using backend.Models;

namespace backend.DataMapper
{
    public static class ClientBookingMapper
    {
        public static ClientBooking ToCreateClientBooking(this ClientBookingDto clientModel){
            return new ClientBooking{
                selectedService = clientModel.SelectedService,
                     duration = clientModel.duration,
                BookingId = clientModel.BookingId
            };
        }
        public static ClientBookingDto TogetallService (this ClientBooking clientBooking){
            return new ClientBookingDto {
                SelectedService = clientBooking.selectedService,
                duration = clientBooking.duration,
                BookingId = clientBooking.BookingId,
                
                
            };
        }
    }
}