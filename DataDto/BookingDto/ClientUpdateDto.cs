using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto.Bookingdto
{
    public class ClientUpdateDto
    {
      public int Id {get;set;}
        public string CustomerName { get; set; }
           public string CustomerPhone {get;set;}
              public string Email { get; set; }
    }
}