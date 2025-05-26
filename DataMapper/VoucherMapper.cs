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
        public static string ConfirmVoucherEmail(GetVoucherCodeDto getVoucherCodeDto,string code){
            return $@"
            <html>
  <body style='font-family: Arial, sans-serif; background-color: #f5f5f5; padding: 30px;'>
    <div style='max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 10px; box-shadow: 0 4px 12px rgba(0,0,0,0.1);'>

      <!-- Header -->
      <div style='background-color: #fce4ec; padding: 30px 20px; text-align: center;'>
        <h1 style='margin: 0; font-size: 30px; color: #d63384;'>AivyBeauty</h1>
        <p style='margin: 5px 0 0; font-size: 15px; color: #888;'>Where beauty begins 💅</p>
      </div>

      <!-- Content -->
     <div style='padding: 30px; font-size: 15px; color: #333; line-height: 1.7;'>
        <p>Hi <strong>{getVoucherCodeDto.Username}</strong>,</p>
        <p>Thank you for your recent voucher purchase!</p>
        <p><strong>Voucher Code:</strong> {code}</p>
        <p><strong>Total Value:</strong> ${getVoucherCodeDto.TotalAmount}</p>
        <p>We truly appreciate your trust and look forward to pampering you soon.</p>
      </div>

      <!-- Footer -->
      <div style='background-color: #fce4ec; padding: 15px; text-align: center; font-size: 13px; color: #666;'>
        © {DateTime.Now.Year} AivyBeauty. All rights reserved.
      </div>

    </div>
  </body>
</html>";
        }
       
    }
}