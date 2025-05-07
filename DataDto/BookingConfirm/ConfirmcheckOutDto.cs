using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.VoucherUsage;

namespace backend.DataDto.BookingConfirm
{
    public class ConfirmcheckOutDto
    {
        public BookingConfirmDto? BookingConfirmDto {get;set;}
        public VoucherUsageDto? VoucherUsageDto {get;set;}

        
    }
}