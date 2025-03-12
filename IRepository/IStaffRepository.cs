using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.IRepository
{
    public interface IStaffRepository
    {
        Task<List<Staff>>AllStaff();
        Task<bool>StaffExist(int id);
    }
}