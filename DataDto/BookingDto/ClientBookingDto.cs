using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto.BookingDto
{
    public class ClientBookingDto
    {
        
        
         public string SelectedService { get; set; }

         public int BookingId { get; set; }
      
    }
}