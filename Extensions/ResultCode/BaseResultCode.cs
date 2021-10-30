using System.Collections.Generic;

namespace IgorMoura.Reminder.Extensions.ResultCode
{
    public class BaseResultCode
    {
        public List<ResultError> Errors { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
