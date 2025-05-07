using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend.Models
{
    public class VoucherUsage
    {
          public int Id { get; set; }

        public int VoucherId { get; set; }

        public decimal UsedAmount { get; set; }

        public DateTime UsedAt { get; set; } = DateTime.UtcNow;

        public string UsedBy { get; set; }

        public int? BookingConfirmId { get; set; }
    [JsonIgnore] 
        public BookingConfirm BookingConfirm{get;set;}

     
        public Voucher Voucher { get; set; }
    }
}