using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto.StaffDto
{
    public class EditStaffInforDto
    {
        
        public int StaffId { get; set; }
        public string FullName { get; set; }


        public string PhoneNumber { get; set; }


        public string IsActive { get; set; }

        public List<EditStaffScheduleDto> EditStaffScheduleDtos { get; set; } = new List<EditStaffScheduleDto>();
    }
}