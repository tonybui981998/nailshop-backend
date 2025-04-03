using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.CustomerRequireddto;
using backend.Models;

namespace backend.DataMapper
{
    public static class CustomerRequiredMapper
    {
        public static CustomerRequiredDto TogetallRequired (this CustomerRequired customerRequired){
            return new CustomerRequiredDto{
                Id = customerRequired.Id,
                FullName = customerRequired.FullName,
                Email = customerRequired.Email,
                Phone = customerRequired.Phone,
                Content = customerRequired.Content

            };
        }
    }
}