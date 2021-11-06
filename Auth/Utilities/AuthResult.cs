using System.Net;
using System.Collections.Generic;

namespace IgorMoura.Reminder.Auth.Utilities
{
    public class AuthResult<T>
    {
        public HttpStatusCode StatusCode { get; private set; }
        public T Data { get; private set; }
        public List<AuthError> Errors { get; private set; }

        public AuthResult(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public AuthResult(HttpStatusCode statusCode, T data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public AuthResult(HttpStatusCode statusCode, List<AuthError> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}
