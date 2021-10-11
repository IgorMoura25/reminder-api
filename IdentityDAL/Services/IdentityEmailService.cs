using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using IgorMoura.IdentityDAL.Entities;

namespace IgorMoura.IdentityDAL.Services
{
    public class IdentityEmailService
    {
        private readonly string _emailUserName = "reminder.applications@gmail.com";
        private readonly string _emailPassword = "Cercatrova2501";

        public async Task SendEmailAsync(IdentityEmailEntity identityEmail)
        {
            using(var mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(_emailUserName);
                mailMessage.Subject = identityEmail.Subject;
                mailMessage.To.Add(identityEmail.Destination);
                mailMessage.Body = identityEmail.Body;

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(_emailUserName, _emailPassword);

                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.Timeout = 20000;

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
        }
    }
}
