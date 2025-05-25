using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto.VoucherDto
{
    public class GetVoucherCodeDto
    {
    public string Username { get; set; }
    public string Email { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    }
}