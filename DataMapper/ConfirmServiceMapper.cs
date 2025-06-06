using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.ConfirmService;
using backend.Models;

namespace backend.DataMapper
{
    public static class ConfirmServiceMapper
    {
        public static ConfirmService TogetConfirmService (this ConfirmServiceDto confirmServiceDto){
            return new ConfirmService{
                selectedService = confirmServiceDto.selectedService,
                duration = confirmServiceDto.duration,
                price = confirmServiceDto.price,
              //  BookingConfirmId = confirmServiceDto.BookingConfirmId,
                
            };
            
        }
        public static ConfirmServiceCheckDto TogetAllConfirmService (this ConfirmService confirmService){
            return new ConfirmServiceCheckDto{
                selectedService = confirmService.selectedService,
                duration = confirmService.duration,
                price = confirmService.price,
                BookingConfirmId = confirmService.BookingConfirmId,
            };
        }
    }
}