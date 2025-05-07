using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ConfirmService
    {
         public int Id { get; set; }
         public string selectedService { get; set; }

         public string duration {get;set;}

        public int price{get;set;}

        
         public int BookingConfirmId { get; set; }
   
         public BookingConfirm BookingConfirm { get; set; }
    }
}