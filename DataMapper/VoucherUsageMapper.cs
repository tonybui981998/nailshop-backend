using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.VoucherUsage;
using backend.Models;

namespace backend.DataMapper
{
    public static class VoucherUsageMapper
    {
        public static VoucherUsage ToRecordUse (this VoucherUsageDto voucherUsageDto){
            return new VoucherUsage{
                VoucherId = voucherUsageDto.VoucherId,
                UsedAmount = voucherUsageDto.UsedAmount,
                UsedBy = voucherUsageDto.UsedBy,
               BookingConfirmId = voucherUsageDto.BookingConfirmId
            };
        }
    }
}