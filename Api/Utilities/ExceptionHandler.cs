using System;
using System.Net;
using System.Collections.Generic;
using IgorMoura.Reminder.Extensions.Exceptions.Reminder;

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
                return new ApiResult<T>(HttpStatusCode.NotFound, new List<ApiError>() { new ApiError { InternalMessage = GetExceptionMessage(ex.Message), Code = GetExceptionMessageCode(ex.Message) } });
            }

            return new ApiResult<T>(HttpStatusCode.InternalServerError, new List<ApiError>() { new ApiError { InternalMessage = _internalServerErrorDefaultMessage, Code = _internalServerErrorCode } });
        }

        private static string GetExceptionMessageCode(string message)
        {
            var splittedString = message.Split(':');
            return splittedString[0].Trim();
        }

        private static string GetExceptionMessage(string message)
        {
            var splittedString = message.Split(':');
            return splittedString[1].TrimStart();
        }
    }
}
