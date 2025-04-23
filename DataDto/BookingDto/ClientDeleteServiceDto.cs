using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto.Bookingdto
{
    public class ClientDeleteServiceDto
    {
         public string selectedService { get; set; }
              public int BookingId { get; set; }
    }
}