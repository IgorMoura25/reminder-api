using System.Collections.Generic;

namespace IgorMoura.Reminder.Extensions.ResultCode.User
{
    public class UserResultCode : BaseResultCode
    {
        public BaseResultCode AddOperationError { get { return new BaseResultCode() { Code = "AddOperationError", Message = "Some errors ocurred while processing the request" }; } }
        public BaseResultCode ConfirmEmailOperationError { get { return new BaseResultCode() { Code = "ConfirmEmailOperationError", Message = "Some errors ocurred while processing the request" }; } }
        public BaseResultCode UserAlreadyExist { get { return new BaseResultCode() { Code = "UserAlreadyExist", Message = "User already exist" }; } }
        public BaseResultCode UserNotFound { get { return new BaseResultCode() { Code = "UserNotFound", Message = "User was not found" }; } }
        public BaseResultCode IncorrectPassword { get { return new BaseResultCode() { Code = "IncorrectPassword", Message = "Incorrect password" }; } }
    }
}
