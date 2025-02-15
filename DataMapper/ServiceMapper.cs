using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.Service;
using backend.Models;

namespace backend.DataMapper
{
    public static class ServiceMapper
    {
        public static ServiceDto GetAllData (this Service servicemodel){
            return new ServiceDto{
                Id = servicemodel.Id,
                Title = servicemodel.Title,
                ServiceOptionDtos = servicemodel.ServiceOptions.Select(x=>x.GetAllOptions()).ToList()
                
            };
        }
    }
}