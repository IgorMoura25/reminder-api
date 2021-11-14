namespace IgorMoura.Reminder.Extensions.ResultCode.Auth
{
    public class AuthResultCode : BaseResultCode
    {
        public BaseResultCode UserOrPasswordIncorrect { get { return new BaseResultCode() { Code = "UserOrPasswordIncorrect", Message = "User or password is incorrect" }; } }
        public BaseResultCode UserLockedOut { get { return new BaseResultCode() { Code = "UserLockedOut", Message = "User is locked due to failed access attempts" }; } }
        public BaseResultCode EmailNotConfirmed { get { return new BaseResultCode() { Code = "EmailNotConfirmed", Message = "Email is not confirmed" }; } }
        public BaseResultCode ResetPasswordOperationError { get { return new BaseResultCode() { Code = "ResetPasswordOperationError", Message = "An error ocurred while reseting password" }; } }

    }
}
