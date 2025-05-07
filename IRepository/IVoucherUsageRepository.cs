using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.VoucherUsage;
using backend.Models;

namespace backend.IRepository
{
    public interface IVoucherUsageRepository
    {
        Task<VoucherUsage> CreateUseAsync (VoucherUsageDto voucherUsageDto);
    }
}