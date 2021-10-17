using System;

namespace IgorMoura.Reminder.Extensions.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException() : base("User already exist")
        {
        }

        public readonly string Code = "UserAlreadyExist";
    }
}
