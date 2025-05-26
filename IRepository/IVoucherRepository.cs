using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.VoucherDto;
using backend.Models;

namespace backend.IRepository
{
    public interface IVoucherRepository
    {
        Task<Voucher>CheckExistAsync(VoucherCheckDto voucherCheckDto);
        Task<Voucher>CheckVoucherAsync(string code , decimal RemainingAmount);

        Task<Voucher>CheckVoucherAutoAsync(string code);
        Task<string> GenerateCodeAsync(int length = 8);

        Task<Voucher>GetAuoGenetaCodeAsync(GetVoucherCodeDto getVoucherCodeDto);

        Task SendEmailAsync (GetVoucherCodeDto getVoucherCodeDto, string code);

        
    }
}