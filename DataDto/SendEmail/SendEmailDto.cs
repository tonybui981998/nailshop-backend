using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto.SendEmail
{
    public class SendEmailDto
    {
    public string ToEmail { get; set; }
   
    public string Body { get; set; }
    public string CustomerName { get; set; }
    }
}