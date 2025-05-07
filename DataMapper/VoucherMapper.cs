using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.VoucherDto;
using backend.Models;

namespace backend.DataMapper
{
    public static class VoucherMapper
    {
        public static VoucherRepondDto TogetCheckVoucher(this Voucher voucher){
            return new VoucherRepondDto{
                TotalAmount = voucher.TotalAmount,
                RemainingAmount = voucher.RemainingAmount
            };
        }
    }
}