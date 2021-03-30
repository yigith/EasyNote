using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace EasyNote.Utilities
{
    public static class EmailUtility
    {
        public static async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["SmtpUserName"],
                    ConfigurationManager.AppSettings["SmtpPassword"]
                );
                MailMessage message = new MailMessage("easynote@kod.fun", to, subject, body);
                message.IsBodyHtml = true;
                await smtp.SendMailAsync(message);
            }
        }
    }
}