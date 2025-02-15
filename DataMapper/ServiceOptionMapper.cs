using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.ServiceOption;
using backend.Models;

namespace backend.DataMapper
{
    public static class ServiceOptionMapper
    {
        public static ServiceOptionDto GetAllOptions (this ServiceOptions optionmodel){
            return new ServiceOptionDto{
                Id = optionmodel.Id,
                Name = optionmodel.Name,
                Duration = optionmodel.Duration,
                Price = optionmodel.Price,
                ServiceId = optionmodel.ServiceId
            };
        }
    }
}