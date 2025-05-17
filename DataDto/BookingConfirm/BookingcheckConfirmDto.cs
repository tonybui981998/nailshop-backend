using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.ConfirmService;

namespace backend.DataDto.BookingConfirm
{
    public class BookingcheckConfirmDto
    {
         public int? VoucherAmount{get;set;}
         public string? VoucherCode {get;set;}
             public string BookingStatus { get; set; }
         public int Discount { get; set; }
          public decimal TotalPay {get;set;}
          public int BookingId{get;set;}


          public string CusName{get;set;}

          public string CusPhone {get;set;}

          public List<ConfirmServiceCheckDto> Service{get;set;} = new List<ConfirmServiceCheckDto>();
    }
}