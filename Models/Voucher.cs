using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Voucher
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? ExpireDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<VoucherUsage> VoucherUsages{get;set;} = new List<VoucherUsage>();
    }
}