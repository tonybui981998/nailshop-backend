using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto.VoucherUsage
{
    public class VoucherUsageDto
    {
                public int VoucherId { get; set; }

                  public decimal UsedAmount { get; set; }

                  public string UsedBy { get; set; }

                    public int? BookingConfirmId { get; set; }
    }
}