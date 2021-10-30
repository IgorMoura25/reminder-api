namespace IgorMoura.Reminder.Extensions.ResultCode.Reminder
{
    public class ReminderResultCode : BaseResultCode
    {
        public BaseResultCode ReminderNotFound { get { return new BaseResultCode() { Code = "ReminderNotFound", Message = "Reminder was not found" }; } }
    }
}
