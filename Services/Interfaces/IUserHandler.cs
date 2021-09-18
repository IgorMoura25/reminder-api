using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Services.Interfaces
{
    public interface IUserHandler
    {
        public long AddUser(UserEntity user);
    }
}
