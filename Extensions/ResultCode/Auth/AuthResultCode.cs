namespace IgorMoura.Reminder.Extensions.ResultCode.Auth
{
    public class AuthResultCode : BaseResultCode
    {
        public BaseResultCode UserOrPasswordIncorrect { get { return new BaseResultCode() { Code = "UserOrPasswordIncorrect", Message = "User or password is incorrect" }; } }
    }
}
