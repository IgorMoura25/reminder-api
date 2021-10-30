using IgorMoura.Reminder.Extensions.ResultCode;

namespace IgorMoura.Reminder.Services
{
    public class ServiceResult<T>
    {
        public bool Succeeded { get; internal set; }
        public T Data { get; internal set; }
        public string Code { get; internal set; }
        public string Message { get; internal set; }
        public BaseResultCode Result { get; internal set; }
    }

    public static class ServiceResultBuilder<T>
    {
        public static ServiceResult<T> Success(T data)
        {
            return new ServiceResult<T>()
            {
                Succeeded = true,
                Data = data,
                Code = "SUCCESS",
                Message = "Operation was successful"
            };
        }

        public static ServiceResult<T> Error(BaseResultCode code)
        {
            return new ServiceResult<T>()
            {
                Succeeded = false,
                Code = code.Code,
                Message = code.Message,
                Result = code
            };
        }
    }
}
