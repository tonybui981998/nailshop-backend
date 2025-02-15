using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto.ServiceOption
{
    public class ServiceOptionDto
    {
         public int Id { get; set; }


        public string Name { get; set; } = string.Empty;
     
        public string Duration { get; set; } = string.Empty;
    
          public decimal? Price { get; set; }
            public int ServiceId { get; set; }
    }
}