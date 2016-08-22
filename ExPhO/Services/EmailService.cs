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
        private const string EMAIL = "expho@gmail.com";
        private const string PASSWORD = "password";
        public Task SendAsync(IdentityMessage message)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(EMAIL, PASSWORD);           
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