using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.ServiceOption;


namespace backend.DataDto.Service
{
    public class ServiceDto
    {
          public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

      public List<ServiceOptionDto> ServiceOptionDtos {get;set;}
    }
}