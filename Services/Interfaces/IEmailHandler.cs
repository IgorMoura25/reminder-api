using System.Threading.Tasks;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Services.Interfaces
{
    public interface IEmailHandler
    {
        public Task SendEmailAsync(EmailEntity identityEmail);
    }
}
