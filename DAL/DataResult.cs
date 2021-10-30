using System.Collections.Generic;
using IgorMoura.Reminder.Extensions.ResultCode;

namespace IgorMoura.Reminder.DAL
{
    public class DataResult<T>
    {
        public bool Succeeded { get; internal set; }
        public T Data { get; internal set; }
        public string Code { get; internal set; }
        public string Message { get; internal set; }
        public BaseResultCode Result { get; internal set; }
        public List<DataResultError> Errors { get; internal set; }
    }

    public static class DataResultBuilder<T>
    {
        public static DataResult<T> Success(T data)
        {
            return new DataResult<T>()
            {
                Succeeded = true,
                Data = data
            };
        }

        public static DataResult<T> Error(BaseResultCode code)
        {
            return new DataResult<T>()
            {
                Succeeded = false,
                Code = code.Code,
                Message = code.Message,
                Result = code
            };
        }

        public static DataResult<T> Errors(BaseResultCode code, List<DataResultError> errors)
        {
            return new DataResult<T>()
            {
                Succeeded = false,
                Code = code.Code,
                Message = code.Message,
                Result = code,
                Errors = errors
            };
        }
    }

    public class DataResultError
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
