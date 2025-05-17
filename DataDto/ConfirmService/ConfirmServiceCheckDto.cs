using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto.ConfirmService
{
    public class ConfirmServiceCheckDto
    {
         public string selectedService { get; set; }

         public string duration {get;set;}

        public int price{get;set;}

         public int BookingConfirmId { get; set; }
    }
}