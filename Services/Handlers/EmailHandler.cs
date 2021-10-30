using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using IgorMoura.Reminder.Models.Entities;
using IgorMoura.Reminder.Services.Interfaces;

namespace IgorMoura.Reminder.Services.Handlers
{
    public class EmailHandler : IEmailHandler
    {
        private string _emailUserName { get; set; }
        private string _emailPassword { get; set; }
        private string _emailHost { get; set; }

        public EmailHandler(string emailHost, string emailUserName, string emailPassword)
        {
            _emailHost = emailHost;
            _emailUserName = emailUserName;
            _emailPassword = emailPassword;
        }

        public async Task SendEmailAsync(EmailEntity identityEmail)
        {
            using (var mailMessage = new MailMessage())
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
                    smtpClient.Host = _emailHost;
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.Timeout = 20000;

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
        }
    }
}
