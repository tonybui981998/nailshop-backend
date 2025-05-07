using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class BookingConfirm
    {
        [Key]
        public int Id { get; set; }

        public string BookingStatus { get; set; }

        public int Discount { get; set; }

        public string? VoucherCode {get;set;}

        public int? VoucherAmount{get;set;}

        public decimal TotalPay {get;set;}

        public int BookingId{get;set;}
        public Booking Booking {get;set;}

        public VoucherUsage VoucherUsage{get;set;}

        public List<ConfirmService> ConfirmServices {get;set;} = new List<ConfirmService>();

          public DateTime CreateAt {get;set;} = DateTime.UtcNow;
    }
}