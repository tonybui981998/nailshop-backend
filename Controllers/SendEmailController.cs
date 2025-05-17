using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using backend.DataDto.SendEmail;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/send")]
    public class SendEmailController :ControllerBase
    {
        [HttpPost("admin-email")]
        public async Task<IActionResult>SendEmail([FromBody] SendEmailDto sendEmailDto ){
            if(string.IsNullOrWhiteSpace(sendEmailDto.ToEmail) || string.IsNullOrWhiteSpace(sendEmailDto.Body) || sendEmailDto.CustomerName == null){
                return Ok(new { status = "error", message = "sorry missing information" });
            }
            
  var fromEmail = "anhbui981998@gmail.com";       
                var emailPassword = "suyb nntx krxr qeou";   
                var smtpClient = new SmtpClient("smtp.gmail.com") {
                    Port = 587,
                    Credentials = new NetworkCredential(fromEmail,emailPassword),
                    EnableSsl = true
                };
         
  string emailHtml = $@"
<html>
  <body style='font-family: Arial, sans-serif; background-color: #f5f5f5; padding: 30px;'>
    <div style='max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 10px; box-shadow: 0 4px 12px rgba(0,0,0,0.1); overflow: hidden;'>

      <!-- Header -->
      <div style='background-color: #fce4ec; padding: 30px 20px; text-align: center;'>
        <h1 style='margin: 0; font-size: 30px; color: #d63384;'>AivyBeauty</h1>
        <p style='margin: 5px 0 0; font-size: 15px; color: #888;'>Where beauty begins 💅</p>
      </div>

      <!-- Content -->
      <div style='padding: 30px; font-size: 15px; color: #333; line-height: 1.7;'>
        <p>Hi <strong>{sendEmailDto.CustomerName}</strong>,</p>
        <p style='white-space: pre-line;'>{sendEmailDto.Body}</p>
        <p>We truly appreciate your trust and look forward to pampering you soon.</p>

        <hr style='margin: 30px 0; border: none; border-top: 1px solid #eee;' />

        <p style='font-size: 14px; color: #555; line-height: 1.6;'>
          📍 123 Beauty Street, Auckland<br/>
          📞 022-548-8582<br/>
          🌐 <a href='https://www.facebook.com/aivybeautynz' style='color: #d63384; text-decoration: none;'>www.aivybeauty.nz</a>
        </p>

        <p style='margin-top: 25px; font-style: italic; color: #999;'>— AivyBeauty Team</p>
      </div>

      <!-- Footer -->
      <div style='background-color: #fce4ec; padding: 15px; text-align: center; font-size: 13px; color: #666;'>
        © {DateTime.Now.Year} AivyBeauty. All rights reserved.
      </div>

    </div>
  </body>
</html>";

    var mailMessage = new MailMessage{
        From = new MailAddress(fromEmail),
        Subject = "Message from love nails Aivy beauty",
        Body = emailHtml,
        IsBodyHtml = true

    };
    mailMessage.To.Add(sendEmailDto.ToEmail);
    try{
  smtpClient.Send(mailMessage);
  return Ok(new {status = "success",message ="send success"});
    }catch(Exception ex){
          return Ok(new { status = "error", message = "Failed to send message"});
    }
  
   
        }
        
    }

 
  }
