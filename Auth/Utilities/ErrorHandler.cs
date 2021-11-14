using System.Net;
using System.Collections.Generic;
using IgorMoura.Reminder.Extensions.ResultCode;
using IgorMoura.Reminder.Extensions.ResultCode.Auth;

namespace IgorMoura.Reminder.Auth.Utilities
{
    public static class ErrorHandler
    {
        private static readonly string _internalServerErrorCode = "UnknownError";
        private static readonly string _internalServerErrorDefaultMessage = "An internal unknown error ocurred";

        public static AuthResult<T> HandleAuthorizationErrors<T>(BaseResultCode resultCode)
        {
            if (string.Equals(new AuthResultCode().UserOrPasswordIncorrect.Code, resultCode.Code))
            {
                return new AuthResult<T>(HttpStatusCode.BadRequest, new List<AuthError>() { new AuthError { InternalMessage = resultCode.Message, Code = resultCode.Code } });
            }

            if (string.Equals(new AuthResultCode().UserLockedOut.Code, resultCode.Code))
            {
                return new AuthResult<T>(HttpStatusCode.Forbidden, new List<AuthError>() { new AuthError { InternalMessage = resultCode.Message, Code = resultCode.Code } });
            }

            if (string.Equals(new AuthResultCode().EmailNotConfirmed.Code, resultCode.Code))
            {
                return new AuthResult<T>(HttpStatusCode.Forbidden, new List<AuthError>() { new AuthError { InternalMessage = resultCode.Message, Code = resultCode.Code } });
            }

            return new AuthResult<T>(HttpStatusCode.InternalServerError, new List<AuthError>() { new AuthError { InternalMessage = _internalServerErrorDefaultMessage, Code = _internalServerErrorCode } });
        }
    }
}
