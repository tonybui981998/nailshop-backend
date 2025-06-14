using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.CustomScheduleDto;
using backend.Models;

namespace backend.IRepository
{
    public interface ICustomScheduleRepository
    {
        Task<CustomSchedule> UpdateCustomAsync(EditCustomSchedule editCustomSchedule);
    }
}