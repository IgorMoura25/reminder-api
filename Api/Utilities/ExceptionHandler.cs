using System;
using System.Net;
using System.Collections.Generic;
using IgorMoura.Reminder.Extensions.Exceptions;

namespace IgorMoura.Reminder.Api.Utilities
{
    public static class ExceptionHandler
    {
        private static readonly string _internalServerErrorCode = "UNKNOWN_ERROR";
        private static readonly string _internalServerErrorDefaultMessage = "An internal unknown error ocurred";

        public static ApiResult<T> HandleReminderErrors<T>(Exception ex)
        {
            if (ex is ReminderNotFoundException)
            {
                var derivedException = (ReminderNotFoundException)ex;
                return new ApiResult<T>(HttpStatusCode.NotFound, new List<ApiError>() { new ApiError { InternalMessage = derivedException.Message, Code = derivedException.Code } });
            }

            return new ApiResult<T>(HttpStatusCode.InternalServerError, new List<ApiError>() { new ApiError { InternalMessage = _internalServerErrorDefaultMessage, Code = _internalServerErrorCode } });
        }

        public static ApiResult<T> HandleUserErrors<T>(Exception ex)
        {
            if (ex is UserAlreadyExistException)
            {
                var derivedException = (UserAlreadyExistException)ex;
                return new ApiResult<T>(HttpStatusCode.BadRequest, new List<ApiError>() { new ApiError { InternalMessage = derivedException.Message, Code = derivedException.Code } });
            }

            if (ex is InvalidIdentityOperationException)
            {
                var derivedException = (InvalidIdentityOperationException)ex;
                var listErrors = derivedException.IdentityResultErrors?.ConvertAll(x => new ApiError()
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
