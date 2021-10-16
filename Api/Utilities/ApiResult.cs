using System.Net;
using System.Collections.Generic;

namespace IgorMoura.Reminder.Api.Utilities
{
    public class ApiResult<T>
    {
        public HttpStatusCode StatusCode { get; private set; }
        public T Data { get; private set; }
        public List<ApiError> Errors { get; private set; }

        public ApiResult(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public ApiResult(HttpStatusCode statusCode, T data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public ApiResult(HttpStatusCode statusCode, List<ApiError> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}
