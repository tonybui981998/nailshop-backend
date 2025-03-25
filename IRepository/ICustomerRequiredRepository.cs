using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.IRepository
{
    public interface ICustomerRequiredRepository
    {
        Task<CustomerRequired> CreateRequireAsync(CustomerRequired customerRequired);
    }
}