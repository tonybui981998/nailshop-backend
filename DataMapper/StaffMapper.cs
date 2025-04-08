using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.StaffDto;
using backend.Models;

namespace backend.DataMapper
{
    public static class StaffMapper
    {
        private static string ImageBaseUrl  ="http://localhost:5215/Image";
        public static StaffDto ToAllStaff (this Staff staffModel){
            return new StaffDto{
                Id = staffModel.Id,
                FullName = staffModel.FullName,
                IsActive = staffModel.IsActive,
                Image  = string.IsNullOrEmpty(staffModel.Image) ? null : $"{ImageBaseUrl}/{staffModel.Image}",
                StaffScheduleDtos = staffModel.StaffSchedules.Select(x=>x.ToAllSchedule()).ToList()
            };
        }
        public static StaffAdminDto TogetAllAdminStaff (this Staff staffModel){
            return new StaffAdminDto{
                Id = staffModel.Id,
                FullName = staffModel.FullName,
                IsActive = staffModel.IsActive,
                StaffScheduleDtos = staffModel.StaffSchedules.Select(x=>x.ToAllSchedule()).ToList(),
                CustomerScheduleDtos = staffModel.CustomSchedules.Select(u=>u.TogetallCustomSchedule()).ToList(),
            };
        }
    }
}