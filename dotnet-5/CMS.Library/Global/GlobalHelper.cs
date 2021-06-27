using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CMS.BL.Global
{
    public static class GlobalHelper
    {
        public static async Task SendEmail(string toAddr, string mes)
        {
            string FromName = "Conference Management System";
            string FromEmail = "address@email";

            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            //message.To.Add(new MailAddress("recipient@gmail.com"));  // replace with valid value 
            message.To.Add(new MailAddress(toAddr));  // replace with valid value 
                                                      //message.From = new MailAddress("sender@outlook.com");  // replace with valid value
            message.From = new MailAddress("address@email");  // replace with valid value
            message.Subject = "Your email subject";
            message.Body = string.Format(body, FromName, FromEmail, mes);
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "address@email",  // replace with valid value
                    Password = "password"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.live.com";
                //smtp.Host = "smtp.monash.edu.au";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }
    }
}
