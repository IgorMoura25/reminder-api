using System;
using System.Net;
using System.Collections.Generic;
using IgorMoura.Reminder.Extensions.ResultCode;
using IgorMoura.Reminder.Extensions.ResultCode.Reminder;
using IgorMoura.Reminder.Extensions.ResultCode.User;

namespace IgorMoura.Reminder.Api.Utilities
{
    public static class ErrorHandler
    {
        private static readonly string _internalServerErrorCode = "UnknownError";
        private static readonly string _internalServerErrorDefaultMessage = "An internal unknown error ocurred";

        public static ApiResult<T> HandleReminderErrors<T>(BaseResultCode resultCode)
        {
            if (string.Equals(new ReminderResultCode().ReminderNotFound.Code, resultCode.Code))
            {
                return new ApiResult<T>(HttpStatusCode.NotFound, new List<ApiError>() { new ApiError { InternalMessage = resultCode.Message, Code = resultCode.Code } });
            }

            return new ApiResult<T>(HttpStatusCode.InternalServerError, new List<ApiError>() { new ApiError { InternalMessage = _internalServerErrorDefaultMessage, Code = _internalServerErrorCode } });
        }

        public static ApiResult<T> HandleUserErrors<T>(BaseResultCode resultCode)
        {
            if (string.Equals(new UserResultCode().UserAlreadyExist.Code, resultCode.Code))
            {
                return new ApiResult<T>(HttpStatusCode.BadRequest, new List<ApiError>() { new ApiError { InternalMessage = resultCode.Message, Code = resultCode.Code } });
            }

            if (string.Equals(new UserResultCode().UserNotFound.Code, resultCode.Code))
            {
                return new ApiResult<T>(HttpStatusCode.NotFound, new List<ApiError>() { new ApiError { InternalMessage = resultCode.Message, Code = resultCode.Code } });
            }

            if (string.Equals(new UserResultCode().AddOperationError.Code, resultCode.Code))
            {
                var listErrors = resultCode.Errors?.ConvertAll(x => new ApiError()
                {
                    InternalMessage = x.Description,
                    Code = x.Code
                });

                return new ApiResult<T>(HttpStatusCode.BadRequest, listErrors);
            }

            if (string.Equals(new UserResultCode().ConfirmEmailOperationError.Code, resultCode.Code))
            {
                var listErrors = resultCode.Errors?.ConvertAll(x => new ApiError()
                {
                    InternalMessage = x.Description,
                    Code = x.Code
                });

                return new ApiResult<T>(HttpStatusCode.BadRequest, listErrors);
            }

            return new ApiResult<T>(HttpStatusCode.InternalServerError, new List<ApiError>() { new ApiError { InternalMessage = _internalServerErrorDefaultMessage, Code = _internalServerErrorCode } });
        }

        public static ApiResult<T> HandleAuthorizationErrors<T>(Exception ex)
        {
            return new ApiResult<T>(HttpStatusCode.InternalServerError, new List<ApiError>() { new ApiError { InternalMessage = _internalServerErrorDefaultMessage, Code = _internalServerErrorCode } });
        }
    }
}
