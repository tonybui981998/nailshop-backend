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
                Id = voucher.Id,
                TotalAmount = voucher.TotalAmount,
                RemainingAmount = voucher.RemainingAmount
            };
        }
        public static Voucher ToSaveVoucher (this GetVoucherCodeDto getVoucherCodeDto,string code){
            return new Voucher{
                Code = code,
                TotalAmount = getVoucherCodeDto.TotalAmount,
                RemainingAmount = getVoucherCodeDto.TotalAmount
            };
        }
       
    }
}