using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace ExPhO.Services
{
    public class EmailService : IIdentityMessageService
    {
        private const string EMAIL = "expho@ukr.net";
        private const string PASSWORD = "!G\"#rWvXz]/k6z[k";
        public Task SendAsync(IdentityMessage message)
        {
            using (SmtpClient client = new SmtpClient("smtp.ukr.net", 465))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(EMAIL, PASSWORD);
                client.EnableSsl = true;          
                using (MailMessage mailMessage = new MailMessage(EMAIL, message.Destination))
                {
                    mailMessage.Body = message.Body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = message.Subject;
                    client.Send(mailMessage);
                }
            }
            return Task.FromResult(0);
        }
    }
}